using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xceed.Words.NET;
using System.Drawing;
using System.IO;
using HCS.StaffManagement.AppUtility;
using System.Text;


namespace HCS.StaffManagement.Models
{
    public class PayslipGeneration
    {

        public void PayslipPDFGeneration(OrganizationPayslip objData, string strPath)
        {
            try
            {
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }

                // Create a document.
                using (DocX doc = DocX.Create(strPath + "Payslip" + DateTime.Now.Second.ToString() + ".doc"))
                {
                    FontFamily font = new FontFamily("Times New Roman");                    
                    //doc.PageWidth = 500;
                    //Row row = table.InsertRow();                    
                    //row.Paragraphs[0].Font(font).FontSize(13);
                    //t1.Rows[0].Alignment = Alignment.center;
                    int i = 0;
                    //Looping through each payslip
                    foreach (PayslipData item in objData.PayslipList)
                    {
                        i = i + 1;
                        if(i%2 != 0 && i > 2)
                        {
                            doc.InsertSectionPageBreak(true);
                        }else if( i > 1)
                        {
                            doc.InsertParagraph("\n");
                        }
                        //Add Table to this document.
                        Table t = doc.AddTable(6, 4);
                        t.Design = TableDesign.TableGrid;
                        t.AutoFit = AutoFit.Contents;

                        // Add a table in a document of 1 row and 3 columns.
                        var columnWidths = new float[] { 270f, 270f, 270f, 270f };
                        // Set the table's column width and background 
                        t.SetWidths(columnWidths);

                        //t.MergeCellsInColumn(1,1,4);
                        //Merging first row for Office address

                        t.Rows[0].MergeCells(0, 3);
                        t.Rows[0].Cells[0].Paragraphs[0].Append(objData.OrganizationProp.OrganizationName).Bold();
                        t.Rows[0].Cells[0].Paragraphs[0].Append("\n" + objData.OrganizationProp.Address1 + ", " + objData.OrganizationProp.Address2);
                        t.Rows[0].Cells[0].Paragraphs[0].Append(", " +objData.OrganizationProp.City + " - " + objData.OrganizationProp.PinCode);
                        t.Rows[0].Cells[0].Paragraphs[0].Append("\n\nPayslip for the month of " + objData.MonthName + " - " + objData.Year.ToString());
                        t.Rows[0].Paragraphs[0].Alignment = Alignment.center;

                        //Second Row for employee information
                        t.Rows[1].MergeCells(0, 1);
                        //Employee Information Left Column
                        t.Rows[1].Cells[0].Paragraphs[0].Append("Name:\t\t\t" + item.EmployeeNo);
                        t.Rows[1].Cells[0].Paragraphs[0].Append("\nDate Of Joining:\t\t" + item.DateofJoin); 
                        t.Rows[1].Cells[0].Paragraphs[0].Append("\nDesignation:\t\t" + item.Designation);
                        t.Rows[1].Cells[0].Paragraphs[0].Append("\nDepartment:\t\t" + item.Department);
                        t.Rows[1].Cells[0].Paragraphs[0].Append("\nLocation:\t\t" + item.Location);
                        t.Rows[1].Cells[0].Paragraphs[0].Append("\nEffective Work Days:\t" + item.WorkingDays);
                        //Employee Information Right Column
                        t.Rows[1].MergeCells(1, 2);
                        t.Rows[1].Cells[1].Paragraphs[0].Append("Employee No:\t" + item.EmployeeNo);
                        t.Rows[1].Cells[1].Paragraphs[0].Append("\nBank Name:\t" + item.BankName);
                        t.Rows[1].Cells[1].Paragraphs[0].Append("\nAccount No:\t" + item.AccountNo);
                        t.Rows[1].Cells[1].Paragraphs[0].Append("\nPF No.:\t\t" + item.PF);
                        t.Rows[1].Cells[1].Paragraphs[0].Append("\nESI No.:\t\t" + item.ESI);
                        t.Rows[1].Cells[1].Paragraphs[0].Append("\nPAN No.:\t" + item.PanNo);

                        //Third row for Headings Earnings / Deductions
                        //t.Rows[2].MergeCells(0, 1);
                        t.Rows[2].Cells[0].Paragraphs[0].Append("Earnings").Bold();//.Highlight(Highlight.none);
                        //t.Rows[2].Cells[1].SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Transparent));
                        t.Rows[2].Cells[1].Paragraphs[0].Append("Amount").Bold().Alignment=Alignment.right;
                        BorderNone(t.Rows[2].Cells[1]);
                        //t.Rows[2].MergeCells(1, 2);
                        t.Rows[2].Cells[2].Paragraphs[0].Append("Deductions").Bold();
                        t.Rows[2].Cells[3].Paragraphs[0].Append("Amount").Bold().Alignment = Alignment.right;
                        BorderNone(t.Rows[2].Cells[3]);

                        //Fourth row for Payment details
                        t.Rows[3].Cells[0].Paragraphs[0].Append("EARNED BASIC");
                        t.Rows[3].Cells[1].Paragraphs[0].Append(DecimalGet(item.BasicPerMonth,2)).Alignment = Alignment.right;
                        BorderNone(t.Rows[3].Cells[1]);

                        t.Rows[3].Cells[2].Paragraphs[0].Append("ADV");
                        t.Rows[3].Cells[3].Paragraphs[0].Append(DecimalGet(item.Advance, 2));
                        BorderNone(t.Rows[3].Cells[3]);

                        t.Rows[3].Cells[0].Paragraphs[0].Append("\nWAGES D.A");
                        t.Rows[3].Cells[1].Paragraphs[0].Append("\n" + DecimalGet(item.WagesDAPerMonth, 2)).Alignment = Alignment.right;

                        t.Rows[3].Cells[2].Paragraphs[0].Append("\nF. ADV");
                        t.Rows[3].Cells[3].Paragraphs[0].Append("\n" + DecimalGet(item.FutureAdvance, 2)).Alignment = Alignment.right;

                        t.Rows[3].Cells[0].Paragraphs[0].Append("\nINCENTIVE");
                        t.Rows[3].Cells[1].Paragraphs[0].Append("\n" + DecimalGet(item.IncentivePerMonth, 2)).Alignment = Alignment.right;

                        t.Rows[3].Cells[2].Paragraphs[0].Append("\nP.F");
                        t.Rows[3].Cells[3].Paragraphs[0].Append("\n" + DecimalGet(item.PF, 2)).Alignment = Alignment.right;
                        
                        t.Rows[3].Cells[0].Paragraphs[0].Append("\nFLEXIBLE ALLOWANCE");
                        t.Rows[3].Cells[1].Paragraphs[0].Append("\n" + DecimalGet(item.FlexibleAllowance, 2)).Alignment = Alignment.right;
                                                
                        t.Rows[3].Cells[2].Paragraphs[0].Append("\nE.S.I");
                        t.Rows[3].Cells[3].Paragraphs[0].Append("\n" + DecimalGet(item.ESI, 2)).Alignment = Alignment.right;

                        t.Rows[3].Cells[2].Paragraphs[0].Append("\nL.I.C");
                        t.Rows[3].Cells[3].Paragraphs[0].Append("\n" + DecimalGet(item.LIC, 2)).Alignment = Alignment.right;

                        t.Rows[3].Cells[2].Paragraphs[0].Append("\nP.T");
                        t.Rows[3].Cells[3].Paragraphs[0].Append("\n" + DecimalGet(item.PT, 2)).Alignment = Alignment.right;

                        t.Rows[3].Cells[2].Paragraphs[0].Append("\nW.W.F");
                        t.Rows[3].Cells[3].Paragraphs[0].Append("\n" + DecimalGet(item.WWF, 2)).Alignment = Alignment.right;

                        //Fifth Row Sum of Payment details
                        t.Rows[4].Cells[0].Paragraphs[0].Append("Total Earnings:");
                        t.Rows[4].Cells[1].Paragraphs[0].Append("Rs. " + DecimalGet(item.Earnings, 2)).Alignment=Alignment.right;
                        BorderNone(t.Rows[4].Cells[1]);
                        t.Rows[4].Cells[2].Paragraphs[0].Append("Total Deductions:");
                        t.Rows[4].Cells[3].Paragraphs[0].Append("Rs. " + DecimalGet(item.Deductions, 2)).Alignment = Alignment.right;
                        BorderNone(t.Rows[4].Cells[3]);

                        //Adding Bottom outline
                        //BorderNone(t.Rows[2].Cells[1], false);
                        //BorderNone(t.Rows[2].Cells[3], false);

                        //Sixth Row net pay 
                        t.Rows[5].MergeCells(0, 3);
                        t.Rows[5].Cells[0].Paragraphs[0].Append("Net Pay for the month (Total Earnings - Total Deductions): " + DecimalGet(item.NetAmount,2));
                        StringBuilder strWord = new StringBuilder();
                        int num = (int)item.NetAmount;
                        NumberToWordConverter.ConvertToString(num, strWord);
                        t.Rows[5].Cells[0].Paragraphs[0].Append("\n(" + strWord.ToString() + ")").Italic();
                        doc.InsertTable(t);
                        doc.InsertParagraph("This is a system generated payslip and does not require signature.").FontSize(10).Alignment = Alignment.center;
                    }

                    
                    doc.Save();
                }// Release this document from memory.
            }
            catch (Exception ex)
            {

            }
        }

        internal string DecimalGet(float flVal, int precession)
        {
            try
            {
                return flVal.ToString("n" + precession.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            
        internal void BorderNone(Cell objCell,bool flag=true)
        {
            if (flag)
            {
                objCell.SetBorder(TableCellBorderType.Left, new Border(BorderStyle.Tcbs_inset, BorderSize.one, 1, Color.Transparent));
            }else
            {
                //objCell.SetBorder(TableCellBorderType.Bottom, new Border(BorderStyle.Tcbs_double, BorderSize.one, 1, Color.Black));
            }
        }

    }
}
