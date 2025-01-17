﻿namespace DataExporter.Application.Dtos
{
    public class ExportDto
    {
        public string? PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }
        public IList<string> Notes { get; set; }
    }
}
