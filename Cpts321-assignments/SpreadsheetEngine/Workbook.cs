// <copyright file="Workbook.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Class for loading and saving spreadsheets.
    /// </summary>
    public class Workbook
    {
        /// <summary>
        /// Loads a spreadsheet from a xml file.
        /// </summary>
        /// <param name="stream"> The input xml file. </param>
        /// <param name="spreadsheet"> The spreadsheet one wants to load to. </param>
        /// <returns> True if successful in loading the file, false otherwise. </returns>
        public bool Load(System.IO.Stream stream, CptS321.Spreadsheet spreadsheet)
        {
            if (stream is null)
            {
                return false;
            }

            if (spreadsheet is null)
            {
                return false;
            }

            try
            {
                XmlReader reader = XmlReader.Create(stream);
                string cellName = null;
                string bgcolor = null;
                string text = null;
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (reader.Name)
                            {
                                case "cell":
                                    cellName = reader.GetAttribute("name");
                                    break;
                                case "bgcolor":
                                    bgcolor = reader.ReadElementContentAsString();
                                    break;
                                case "text":
                                    text = reader.ReadElementContentAsString();
                                    break;
                            }

                            break;

                        case XmlNodeType.EndElement:
                            switch (reader.Name)
                            {
                                case "cell":
                                    if (bgcolor != null || text != null)
                                    {
                                        int[] rowAndCol = CptS321.Spreadsheet.ParseVariableName(cellName);
                                        CptS321.SpreadsheetCell cell = spreadsheet.GetCell(rowAndCol[0], rowAndCol[1]);
                                        if (bgcolor != null)
                                        {
                                            // no alpha specified
                                            if (bgcolor.Length == 6)
                                            {
                                                bgcolor = "FF" + bgcolor;
                                            }

                                            cell.BGColor = uint.Parse(bgcolor, System.Globalization.NumberStyles.HexNumber);
                                            bgcolor = null;
                                        }

                                        if (text != null)
                                        {
                                            cell.Text = text;
                                            text = null;
                                        }
                                    }

                                    break;
                            }

                            break;
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Saves a spreadsheet to an xml file.
        /// </summary>
        /// <param name="stream"> The output xml file. </param>
        /// <param name="spreadsheet"> The spreadsheet to be stored. </param>
        /// <returns> True if successful in saving, false otherwise. </returns>
        public bool Save(System.IO.Stream stream, CptS321.Spreadsheet spreadsheet)
        {
            if (stream is null)
            {
                return false;
            }

            if (spreadsheet is null)
            {
                return false;
            }

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                XmlWriter writer = XmlWriter.Create(stream, settings);
                writer.WriteStartElement("spreadsheet");

                for (int row = 1; row <= spreadsheet.RowCount; row++)
                {
                    for (int col = 1; col <= spreadsheet.ColumnCount; col++)
                    {
                        CptS321.SpreadsheetCell cell = spreadsheet.GetCell(row, col);

                        // check if cell does not have default values
                        if ((cell.Text != CptS321.Globals.SpreadsheetCell.Default_Text && cell.Text != null)
                            || cell.BGColor != CptS321.Globals.SpreadsheetCell.Default_BGColor)
                        {
                            writer.WriteStartElement("cell");
                            writer.WriteAttributeString("name", cell.ToString());

                            if (cell.Text != CptS321.Globals.SpreadsheetCell.Default_Text && cell.Text != null)
                            {
                                writer.WriteStartElement("text");
                                writer.WriteString(cell.Text);
                                writer.WriteEndElement();
                            }

                            if (cell.BGColor != CptS321.Globals.SpreadsheetCell.Default_BGColor)
                            {
                                writer.WriteStartElement("bgcolor");
                                writer.WriteString(cell.BGColor.ToString("X"));
                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();
                        }
                    }
                }

                writer.WriteEndElement();
                writer.Close();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
