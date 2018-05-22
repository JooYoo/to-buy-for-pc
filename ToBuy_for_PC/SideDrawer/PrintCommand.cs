using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace ToBuy_for_PC.SideDrawer
{
    public class PrintCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        public PrintCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var toBuys = viewModel.ToBuys;

            //instance FlowDocument
            FlowDocument fd = new FlowDocument();
            Table table = new Table();

            //
            table.RowGroups.Add(new TableRowGroup());
            table.RowGroups[0].Rows.Add(new TableRow());

            // Header
            TableRow header = table.RowGroups[0].Rows[0];
            header.Cells.Add(new TableCell(new Paragraph(new Run(viewModel.DayWeekTime.ToString()))));
            //header.Cells.Add(new TableCell(new Paragraph(new Run("Name"))));
            //header.Cells.Add(new TableCell(new Paragraph(new Run("IsDone"))));

            // layout
            table.CellSpacing = 50;

            // arrange all cells in the table
            foreach (var toBuy in toBuys)
            {
                table.RowGroups[0].Rows.Add(new TableRow());
                table.RowGroups[0].Rows.Last().Cells.Add(new TableCell(new Paragraph(new Run("[    ]"))));
                table.RowGroups[0].Rows.Last().Cells.Add(new TableCell(new Paragraph(new Run(toBuy.Name))));
            }

            // add to the Doc
            fd.Blocks.Add(table);

            // FlowDoc -> DocumentPaginator
            IDocumentPaginatorSource documentPaginator = fd;

            // To print 
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
            pd.PrintDocument(documentPaginator.DocumentPaginator, "");
        }

        public event EventHandler CanExecuteChanged;
    }
}
