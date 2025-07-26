using System;
using System.Data;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin
{
    internal class PaginationHelper
    {

        private int _pageSize = 10;
        private int _currentPage = 1;
        private int _totalPages = 1;

        public void SetPageSize(int newSize, int totalRows)
        {
            _pageSize = newSize;
            _currentPage = 1;
            CalculateTotalPages(totalRows);
        }


        public (int Start, int End) GetDisplayRange(int totalRows)
        {
            int start = (_currentPage - 1) * _pageSize + 1;
            int end = Math.Min(_currentPage * _pageSize, totalRows);

            if (totalRows == 0) // handle empty state
            {
                start = 0;
                end = 0;
            }

            return (start, end);
        }

        public DataTable ApplyRowLimit(DataTable sourceTable, string selectedValue)
        {
            if (sourceTable == null || string.IsNullOrEmpty(selectedValue))
                return null;

            if (int.TryParse(selectedValue, out int newSize))
            {
                SetPageSize(newSize, sourceTable.Rows.Count);
                return GetPage(sourceTable, _currentPage);

            }

            return sourceTable;
        }


        private void CalculateTotalPages(int rowCount)
        {
            _totalPages = (_pageSize == 0) ? 1 : (int)Math.Ceiling((double)rowCount / _pageSize);
        }

        public DataTable GetPage(DataTable sourceTable, int pageNumber)
        {
            if (sourceTable == null || _pageSize <= 0)
                return sourceTable;

            _currentPage = Math.Max(1, Math.Min(pageNumber, _totalPages));

            var resultTable = sourceTable.Clone();
            int startIndex = (_currentPage - 1) * _pageSize;
            int endIndex = Math.Min(startIndex + _pageSize, sourceTable.Rows.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                resultTable.ImportRow(sourceTable.Rows[i]);
            }

            return resultTable;
        }

        public int CurrentPage => _currentPage;
        public int TotalPages => _totalPages;
        public int PageSize => _pageSize;

        public void ApplyRowLimit(ComboBox comboBox, DataTable sourceTable, DataGridView targetGrid, Label infoLabel)
        {
            if (sourceTable != null)
            {
                string selected = comboBox.SelectedItem.ToString();
                DataTable paged = ApplyRowLimit(sourceTable, selected);

                var (start, end) = GetDisplayRange(sourceTable.Rows.Count);

                infoLabel.Text = $"Showing {start} to {end} of {sourceTable.Rows.Count} entries";
                targetGrid.DataSource = paged;
            }
        }
    }
}
