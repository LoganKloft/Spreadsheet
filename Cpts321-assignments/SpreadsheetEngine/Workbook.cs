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
            return false;

            using (XmlReader reader = XmlReader.Create(stream))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Saves a spreadsheet to an xml file.
        /// </summary>
        /// <param name="stream"> The output xml file. </param>
        /// <param name="spreadsheet"> The spreadsheet to be stored. </param>
        /// <returns> True if successful in saving, false otherwise. </returns>
        public bool Save(System.IO.Stream stream, CptS321.Spreadsheet spreadsheet)
        {
            return false;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                writer.WriteStartElement("spreadsheet");
                writer.WriteEndElement();
                writer.Close();
            }
        }
    }
}
