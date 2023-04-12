using IronXL;
using IronXL.Drawing.Charts;
using IronXL.Formatting;
using IronXL.Formatting.Enums;
using IronXL.Styles;
using MsgBox;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Finance_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static class Globals
        {            
            // Database location string
            public static bool passChecker;
            public static bool bypass;
            public static bool secondChance = false;
            public static bool switchHit = true;
            public static String boxAnswer;
            public static String currentUser;
            public static String currentUserId;
            public static String first;
            public static String last;
            public static String splitText;
            public static String dialogOne = "Enter User's Pass Code:";
            public static String dialogTwo = "Verify Pass Code";
            public static String dialogThree = "Change Title of Selection:";
            public static String dialogFour = "Change Title";
            //public static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            public static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
            public static String firstSelect = "SELECT First,Last FROM People";
            public static String idNameSelect = "SELECT Id FROM People WHERE First = @name";
            public static String longTermSave = "SELECT * FROM LongTermSaves WHERE Id = @id";
            public static String longTermSelect = "SELECT * FROM LongTermTitles WHERE Id = @id";
            public static String moneySelect = "SELECT * FROM Money WHERE Id = @id";
            public static String monthSelect = "SELECT * FROM MonthlyCosts WHERE Id = @id";
            public static String peopleSelect = "SELECT * FROM People WHERE Id = @id";
            public static String selectAllPeople = "SELECT * FROM People";
            public static String selectAllMonCo = "SELECT * FROM MonthlyCosts";
            public static String selectAllMoney = "SELECT * FROM Money";
            public static String selectAllLongTitles = "SELECT * FROM LongTermTitles";
            public static String selectAllLongSaves = "SELECT * FROM LongTermSaves";
            public static String selectWherePeople = "SELECT * FROM People WHERE Id = ";
            public static String selectWhereMonCo = "SELECT * FROM MonthlyCosts WHERE Id = ";
            public static String selectWhereMoney = "SELECT * FROM Money WHERE Id = ";
            public static String selectWhereLongTitles = "SELECT * FROM LongTermTitles WHERE Id = ";
            public static String selectWhereLongSaves = "SELECT * FROM LongTermSaves WHERE Id = ";

            public static String sqlStatement;


        }
        public void ProgressBar(int place)
        {
            
            if (place == 25)
            {
                progressBar1.Value = place;
            }
            else if (place == 50)
            {                
                progressBar1.Value = place;
            }
            else if (place == 75)
            {
                progressBar1.Value = place;
            }
            else
            {
                progressBar1.Value = place;
            }
        }
        private void AdaptTemp(string one, string two, string three, string four, string five)
        {
            // Supported for XLSX, XLS, XLSM, XLTX, CSV and TSV
            WorkBook workBook = WorkBook.Load("Budget_Template.xlsx");
            WorkSheet sheet = workBook.WorkSheets[0];
            WorkSheet sheetTwo = workBook.WorkSheets[1];
            try 
            {
                ProgressBar(25);
                label82.Text = "Creating File";
                //Create database objects to populate data from database
                DataSet ds = new DataSet("DataSetName");
                SqlConnection con;
                SqlDataAdapter da;
                //Open Connection & Fill DataSet
                con = new SqlConnection(Globals.connectionString);
                da = new SqlDataAdapter(one, con);
                con.Open();
                da.Fill(ds);
                foreach (DataTable table in ds.Tables)
                {
                    int Count = table.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= Count + 1; j++)
                    {
                        sheet["AH5"].Value = table.Rows[i]["Id"];
                        sheet["Y2"].Value = table.Rows[i]["First"].ToString().Trim() + " " + table.Rows[i]["Last"].ToString().Trim();
                        sheet["AH2"].Value = table.Rows[i]["Email"].ToString().Trim();
                        sheet["Y3"].Value = table.Rows[i]["Address1"].ToString().Trim();
                        sheet["Y4"].Value = table.Rows[i]["Address2"].ToString().Trim();
                        sheet["Y5"].Value = table.Rows[i]["City"].ToString().Trim();
                        sheet["AH3"].Value = table.Rows[i]["State"].ToString().Trim();
                        sheet["AH4"].Value = table.Rows[i]["Zip"];
                        sheetTwo["AH5"].Value = table.Rows[i]["Id"];
                        sheetTwo["Y2"].Value = table.Rows[i]["First"].ToString().Trim() + " " + table.Rows[i]["Last"].ToString().Trim();
                        sheetTwo["AH2"].Value = table.Rows[i]["Email"].ToString().Trim();
                        sheetTwo["Y3"].Value = table.Rows[i]["Address1"].ToString().Trim();
                        sheetTwo["Y4"].Value = table.Rows[i]["Address2"].ToString().Trim();
                        sheetTwo["Y5"].Value = table.Rows[i]["City"].ToString().Trim();
                        sheetTwo["AH3"].Value = table.Rows[i]["State"].ToString().Trim();
                        sheetTwo["AH4"].Value = table.Rows[i]["Zip"];
                        i++;
                    }

                    Count++;
                }
                DataSet dsTwo = new DataSet("DataSetName");
                SqlConnection conTwo;
                SqlDataAdapter daTwo;
                //Open Connection & Fill DataSet
                conTwo = new SqlConnection(Globals.connectionString);
                daTwo = new SqlDataAdapter(two, conTwo);
                conTwo.Open();
                daTwo.Fill(dsTwo);
                sheet["D12"].Value = "Mortgage".ToString().Trim();
                sheet["D13"].Value = "Electric".ToString().Trim();
                sheet["D14"].Value = "Water".ToString().Trim();
                sheet["D15"].Value = "Gas".ToString().Trim();
                sheet["D16"].Value = "Trash".ToString().Trim();
                sheet["D17"].Value = "Vehicle Payment".ToString().Trim();
                sheet["D18"].Value = "Vehicle Insurance".ToString().Trim();
                sheet["D19"].Value = "Medical Insurance".ToString().Trim();
                sheet["D20"].Value = "Dental Insurance".ToString().Trim();
                sheet["D21"].Value = "Groceries".ToString().Trim();
                sheet["Q12"].Value = "Hulu".ToString().Trim();
                sheet["Q13"].Value = "Netflix".ToString().Trim();
                sheet["Q14"].Value = "Amazon Prime".ToString().Trim();
                sheet["Q15"].Value = "Disney Plus".ToString().Trim();
                sheet["Q16"].Value = "Other Streaming Services".ToString().Trim();
                sheet["Q17"].Value = "Dining Out".ToString().Trim();
                sheet["Q18"].Value = "Vehicle Gas".ToString().Trim();
                sheet["Q19"].Value = "Internet & Cable".ToString().Trim();
                sheet["Q20"].Value = "Cell Phone".ToString().Trim();
                sheet["Q21"].Value = "Child Care".ToString().Trim();

                //Loop through contents of dataset
                foreach (DataTable tableTwo in dsTwo.Tables)
                {
                    int CountTwo = tableTwo.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= CountTwo + 1; j++)
                    {
                        sheet["P52"].Value = tableTwo.Rows[i]["MonthlyOne"];
                        sheet["P53"].Value = tableTwo.Rows[i]["MonthlyTwo"];
                        sheet["P54"].Value = tableTwo.Rows[i]["MonthlyThree"];
                        sheet["P55"].Value = tableTwo.Rows[i]["MonthlyFour"];
                        sheet["P56"].Value = tableTwo.Rows[i]["MonthlyFive"];
                        sheet["P57"].Value = tableTwo.Rows[i]["MonthlySix"];
                        sheet["P58"].Value = tableTwo.Rows[i]["MonthlySeven"];
                        sheet["P59"].Value = tableTwo.Rows[i]["MonthlyEight"];
                        sheet["P60"].Value = tableTwo.Rows[i]["MonthlyNine"];
                        sheet["P61"].Value = tableTwo.Rows[i]["MonthlyTen"];
                        sheet["P63"].Value = tableTwo.Rows[i]["MonthlyEleven"];
                        sheet["P64"].Value = tableTwo.Rows[i]["MonthlyTwelve"];
                        sheet["P65"].Value = tableTwo.Rows[i]["MonthlyThirteen"];
                        sheet["P66"].Value = tableTwo.Rows[i]["MonthlyFourteen"];
                        sheet["P67"].Value = tableTwo.Rows[i]["MonthlyFifteen"];
                        sheet["P68"].Value = tableTwo.Rows[i]["MonthlySixteen"];
                        sheet["P69"].Value = tableTwo.Rows[i]["MonthlySeventeen"];
                        sheet["P70"].Value = tableTwo.Rows[i]["MonthlyEighteen"];
                        sheet["P71"].Value = tableTwo.Rows[i]["MonthlyNineteen"];
                        sheet["P72"].Value = tableTwo.Rows[i]["MonthlyTwenty"];
                        i++;
                    }
                    CountTwo++;
                }
                ProgressBar(30);
                label82.Text = "Creating File.";
                DataSet dsThree = new DataSet("DataSetName");
                SqlConnection conThree;
                SqlDataAdapter daThree;
                //Open Connection & Fill DataSet
                conThree = new SqlConnection(Globals.connectionString);
                daThree = new SqlDataAdapter(three, conThree);
                conThree.Open();
                daThree.Fill(dsThree);
                sheetTwo["C25"].Value = "Donations".ToString().Trim();
                sheetTwo["C26"].Value = "Savings Account".ToString().Trim();
                sheetTwo["C27"].Value = "God Only Knows Fund".ToString().Trim();
                sheetTwo["C28"].Value = "Spending Account".ToString().Trim();
                //Loop through contents of dataset
                foreach (DataTable tableThree in dsThree.Tables)
                {
                    int CountThree = tableThree.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= CountThree + 1; j++)
                    {
                        sheet["T27"].Value = tableThree.Rows[i]["Savings"];
                        sheet["T40"].Value = tableThree.Rows[i]["Spending"];
                        sheetTwo["P25"].Value = tableThree.Rows[i]["Donation"];
                        sheetTwo["P26"].Value = tableThree.Rows[i]["Savings"];
                        sheetTwo["P27"].Value = tableThree.Rows[i]["GOKF"];
                        sheetTwo["P28"].Value = tableThree.Rows[i]["Spending"];
                        i++;
                    }
                    CountThree++;
                }                
                
                ProgressBar(50);
                label82.Text = "Creating File..";
                DataSet dsFour = new DataSet("DataSetName");
                SqlConnection conFour;
                SqlDataAdapter daFour;
                //Open Connection & Fill DataSet
                conFour = new SqlConnection(Globals.connectionString);
                daFour = new SqlDataAdapter(four, conFour);
                conFour.Open();
                daFour.Fill(dsFour);
                //Loop through contents of dataset
                foreach (DataTable tableFour in dsFour.Tables)
                {
                    int CountFour = tableFour.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= CountFour + 1; j++)
                    {
                        sheet["AD12"].Value = tableFour.Rows[i]["ItemOne"].ToString().Trim();
                        sheet["AD13"].Value = tableFour.Rows[i]["ItemTwo"].ToString().Trim();
                        sheet["AD14"].Value = tableFour.Rows[i]["ItemThree"].ToString().Trim();
                        sheet["AD15"].Value = tableFour.Rows[i]["ItemFour"].ToString().Trim();
                        sheet["AD16"].Value = tableFour.Rows[i]["ItemFive"].ToString().Trim();
                        sheet["AD17"].Value = tableFour.Rows[i]["ItemSix"].ToString().Trim();
                        i++;
                    }
                    CountFour++;
                }
                ProgressBar(80);
                label82.Text = "Creating File...";
                DataSet dsFive = new DataSet("DataSetName");
                SqlConnection conFive;
                SqlDataAdapter daFive;
                //Open Connection & Fill DataSet
                conFive = new SqlConnection(Globals.connectionString);
                daFive = new SqlDataAdapter(five, conFive);
                conFive.Open();
                daFive.Fill(dsFive);
                //Loop through contents of dataset
                foreach (DataTable tableFive in dsFive.Tables)
                {
                    int CountFive = tableFive.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= CountFive + 1; j++)
                    {
                        sheet["P74"].Value = tableFive.Rows[i]["SaveOne"];
                        sheet["P75"].Value = tableFive.Rows[i]["SaveTwo"];
                        sheet["P76"].Value = tableFive.Rows[i]["SaveThree"];
                        sheet["P77"].Value = tableFive.Rows[i]["SaveFour"];
                        sheet["P78"].Value = tableFive.Rows[i]["SaveFive"];
                        sheet["P79"].Value = tableFive.Rows[i]["SaveSix"];
                        i++;
                    }
                    CountFive++;
                }
                sheet.Sum();
                sheetTwo.Sum();

                workBook.SaveAs("Budget GUI - "+ comboBox8.Text +".xlsx");
                con.Close();
                conTwo.Close();
                conThree.Close();
                conFour.Close();
                conFive.Close();
                label82.Text = "Creating File....";
                ProgressBar(100);
            }
            catch (Exception ex)
            {
            }
        }
        private void Create_Excel_All(string one, string two, string three, string four, string five)
        {
            ProgressBar(25);
            label82.Text = "Creating File";
            // Create workbook
            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            // Create Seperate sheets for specific databases
            var sheet = workbook.CreateWorkSheet("People");
            var sheetTwo = workbook.CreateWorkSheet("Monthly Costs");
            var sheetThree = workbook.CreateWorkSheet("Money");
            var sheetFour = workbook.CreateWorkSheet("Long Term Titles");
            var sheetFive = workbook.CreateWorkSheet("Long Term Saves");

            // Transfer all database information into Excel Spreadsheet
            try
            {
                //Create database objects to populate data from database
                DataSet ds = new DataSet("DataSetName");
                SqlConnection con;
                SqlDataAdapter da;
                //Open Connection & Fill DataSet
                con = new SqlConnection(Globals.connectionString);
                da = new SqlDataAdapter(one, con);
                con.Open();
                da.Fill(ds);
                sheet["A1"].Value = "Id".ToString().Trim().Trim();
                sheet["B1"].Value = "First Name".ToString().Trim().Trim();
                sheet["C1"].Value = "Last Name".ToString().Trim();
                sheet["D1"].Value = "Email".ToString().Trim();
                sheet["E1"].Value = "Address 1".ToString().Trim();
                sheet["F1"].Value = "Address 2".ToString().Trim();
                sheet["G1"].Value = "City".ToString().Trim();
                sheet["H1"].Value = "State".ToString().Trim();
                sheet["I1"].Value = "Zip Code".ToString().Trim();

                sheet.ProtectSheet("Password");
                sheet.CreateFreezePane(0, 1);
                //Loop through contents of dataset
                foreach (DataTable table in ds.Tables)
                {
                    int Count = table.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= Count + 1; j++)
                    {
                        sheet["A" + j].Value = table.Rows[i]["Id"];
                        sheet["B" + j].Value = table.Rows[i]["First"].ToString().Trim();
                        sheet["C" + j].Value = table.Rows[i]["Last"].ToString().Trim();
                        sheet["D" + j].Value = table.Rows[i]["Email"].ToString().Trim();
                        sheet["E" + j].Value = table.Rows[i]["Address1"].ToString().Trim();
                        sheet["F" + j].Value = table.Rows[i]["Address2"].ToString().Trim();
                        sheet["G" + j].Value = table.Rows[i]["City"].ToString().Trim();
                        sheet["H" + j].Value = table.Rows[i]["State"].ToString().Trim();
                        sheet["I" + j].Value = table.Rows[i]["Zip"];
                        i++;
                    }

                    Count++;
                }
                ProgressBar(25);
                label82.Text = "Creating File.";
                DataSet dsTwo = new DataSet("DataSetName");
                SqlConnection conTwo;
                SqlDataAdapter daTwo;
                //Open Connection & Fill DataSet
                conTwo = new SqlConnection(Globals.connectionString);
                daTwo = new SqlDataAdapter(two, conTwo);
                conTwo.Open();
                daTwo.Fill(dsTwo);
                sheetTwo["A1"].Value = "Id".ToString().Trim();
                sheetTwo["B1"].Value = "Mortgage".ToString().Trim();
                sheetTwo["C1"].Value = "Electric".ToString().Trim();
                sheetTwo["D1"].Value = "Water".ToString().Trim();
                sheetTwo["E1"].Value = "Gas".ToString().Trim();
                sheetTwo["F1"].Value = "Trash".ToString().Trim();
                sheetTwo["G1"].Value = "Vehicle Payment".ToString().Trim();
                sheetTwo["H1"].Value = "Vehicle Insurance".ToString().Trim();
                sheetTwo["I1"].Value = "Medical Insurance".ToString().Trim();
                sheetTwo["J1"].Value = "Dental Insurance".ToString().Trim();
                sheetTwo["K1"].Value = "Groceries".ToString().Trim();
                sheetTwo["L1"].Value = "Hulu".ToString().Trim();
                sheetTwo["M1"].Value = "Netflix".ToString().Trim();
                sheetTwo["N1"].Value = "Amazon Prime".ToString().Trim();
                sheetTwo["O1"].Value = "Disney Plus".ToString().Trim();
                sheetTwo["P1"].Value = "Other Streaming Services".ToString().Trim();
                sheetTwo["Q1"].Value = "Dining Out".ToString().Trim();
                sheetTwo["R1"].Value = "Vehicle Gas".ToString().Trim();
                sheetTwo["S1"].Value = "Internet & Cable".ToString().Trim();
                sheetTwo["T1"].Value = "Cell Phone".ToString().Trim();
                sheetTwo["U1"].Value = "Child Care".ToString().Trim();

                //Loop through contents of dataset
                foreach (DataTable tableTwo in dsTwo.Tables)
                {
                    int CountTwo = tableTwo.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= CountTwo + 1; j++)
                    {
                        sheetTwo["A" + j].Value = tableTwo.Rows[i]["Id"];
                        sheetTwo["B" + j].Value = tableTwo.Rows[i]["MonthlyOne"];
                        sheetTwo["C" + j].Value = tableTwo.Rows[i]["MonthlyTwo"];
                        sheetTwo["D" + j].Value = tableTwo.Rows[i]["MonthlyThree"];
                        sheetTwo["E" + j].Value = tableTwo.Rows[i]["MonthlyFour"];
                        sheetTwo["F" + j].Value = tableTwo.Rows[i]["MonthlyFive"];
                        sheetTwo["G" + j].Value = tableTwo.Rows[i]["MonthlySix"];
                        sheetTwo["H" + j].Value = tableTwo.Rows[i]["MonthlySeven"];
                        sheetTwo["I" + j].Value = tableTwo.Rows[i]["MonthlyEight"];
                        sheetTwo["J" + j].Value = tableTwo.Rows[i]["MonthlyNine"];
                        sheetTwo["K" + j].Value = tableTwo.Rows[i]["MonthlyTen"];
                        sheetTwo["L" + j].Value = tableTwo.Rows[i]["MonthlyEleven"];
                        sheetTwo["M" + j].Value = tableTwo.Rows[i]["MonthlyTwelve"];
                        sheetTwo["N" + j].Value = tableTwo.Rows[i]["MonthlyThirteen"];
                        sheetTwo["O" + j].Value = tableTwo.Rows[i]["MonthlyFourteen"];
                        sheetTwo["P" + j].Value = tableTwo.Rows[i]["MonthlyFifteen"];
                        sheetTwo["Q" + j].Value = tableTwo.Rows[i]["MonthlySixteen"];
                        sheetTwo["R" + j].Value = tableTwo.Rows[i]["MonthlySeventeen"];
                        sheetTwo["S" + j].Value = tableTwo.Rows[i]["MonthlyEighteen"];
                        sheetTwo["T" + j].Value = tableTwo.Rows[i]["MonthlyNineteen"];
                        sheetTwo["U" + j].Value = tableTwo.Rows[i]["MonthlyTwenty"];
                        i++;
                    }
                    CountTwo++;
                }

                DataSet dsThree = new DataSet("DataSetName");
                SqlConnection conThree;
                SqlDataAdapter daThree;
                //Open Connection & Fill DataSet
                conThree = new SqlConnection(Globals.connectionString);
                daThree = new SqlDataAdapter(three, conThree);
                conThree.Open();
                daThree.Fill(dsThree);
                sheetThree["A1"].Value = "Id".ToString().Trim();
                sheetThree["B1"].Value = "Donations".ToString().Trim();
                sheetThree["C1"].Value = "Savings".ToString().Trim();
                sheetThree["D1"].Value = "God Only Knows Funds".ToString().Trim();
                sheetThree["E1"].Value = "Spending".ToString().Trim();
                sheetThree["F1"].Value = "PassCode".ToString().Trim();

                //Loop through contents of dataset
                foreach (DataTable tableThree in dsThree.Tables)
                {
                    int CountThree = tableThree.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= CountThree + 1; j++)
                    {
                        sheetThree["A" + j].Value = tableThree.Rows[i]["Id"];
                        sheetThree["B" + j].Value = tableThree.Rows[i]["Donation"];
                        sheetThree["C" + j].Value = tableThree.Rows[i]["Savings"];
                        sheetThree["D" + j].Value = tableThree.Rows[i]["GOKF"];
                        sheetThree["E" + j].Value = tableThree.Rows[i]["Spending"];
                        sheetThree["F" + j].Value = tableThree.Rows[i]["Pass"];
                        i++;
                    }
                    CountThree++;
                }
                ProgressBar(50);
                label82.Text = "Creating File..";
                DataSet dsFour = new DataSet("DataSetName");
                SqlConnection conFour;
                SqlDataAdapter daFour;
                //Open Connection & Fill DataSet
                conFour = new SqlConnection(Globals.connectionString);
                daFour = new SqlDataAdapter(four, conFour);
                conFour.Open();
                daFour.Fill(dsFour);
                sheetFour["A1"].Value = "Id".ToString().Trim();
                sheetFour["B1"].Value = "Item One".ToString().Trim();
                sheetFour["C1"].Value = "Item Two".ToString().Trim();
                sheetFour["D1"].Value = "Item Three".ToString().Trim();
                sheetFour["E1"].Value = "Item Four".ToString().Trim();
                sheetFour["F1"].Value = "Item Five".ToString().Trim();
                sheetFour["G1"].Value = "Item Six".ToString().Trim();

                //Loop through contents of dataset
                foreach (DataTable tableFour in dsFour.Tables)
                {
                    int CountFour = tableFour.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= CountFour + 1; j++)
                    {
                        sheetFour["A" + j].Value = tableFour.Rows[i]["Id"];
                        sheetFour["B" + j].Value = tableFour.Rows[i]["ItemOne"].ToString().Trim();
                        sheetFour["C" + j].Value = tableFour.Rows[i]["ItemTwo"].ToString().Trim();
                        sheetFour["D" + j].Value = tableFour.Rows[i]["ItemThree"].ToString().Trim();
                        sheetFour["E" + j].Value = tableFour.Rows[i]["ItemFour"].ToString().Trim();
                        sheetFour["F" + j].Value = tableFour.Rows[i]["ItemFive"].ToString().Trim();
                        sheetFour["G" + j].Value = tableFour.Rows[i]["ItemSix"].ToString().Trim();
                        i++;
                    }
                    CountFour++;
                }

                DataSet dsFive = new DataSet("DataSetName");
                SqlConnection conFive;
                SqlDataAdapter daFive;
                //Open Connection & Fill DataSet
                conFive = new SqlConnection(Globals.connectionString);
                daFive = new SqlDataAdapter(five, conFive);
                conFive.Open();
                daFive.Fill(dsFive);
                sheetFive["A1"].Value = "Id".ToString().Trim();
                sheetFive["B1"].Value = "Save One".ToString().Trim().Trim();
                sheetFive["C1"].Value = "Save Two".ToString().Trim();
                sheetFive["D1"].Value = "Save Three".ToString().Trim();
                sheetFive["E1"].Value = "Save Five".ToString().Trim();
                sheetFive["F1"].Value = "Save Five".ToString().Trim();
                sheetFive["G1"].Value = "Save Six".ToString().Trim();

                //Loop through contents of dataset
                foreach (DataTable tableFive in dsFive.Tables)
                {
                    int CountFive = tableFive.Rows.Count;
                    int i = 0;
                    for (int j = 2; j <= CountFive + 1; j++)
                    {
                        sheetFive["A" + j].Value = tableFive.Rows[i]["Id"];
                        sheetFive["B" + j].Value = tableFive.Rows[i]["SaveOne"];
                        sheetFive["C" + j].Value = tableFive.Rows[i]["SaveTwo"];
                        sheetFive["D" + j].Value = tableFive.Rows[i]["SaveThree"];
                        sheetFive["E" + j].Value = tableFive.Rows[i]["SaveFour"];
                        sheetFive["F" + j].Value = tableFive.Rows[i]["SaveFive"];
                        sheetFive["G" + j].Value = tableFive.Rows[i]["SaveSix"];
                        i++;
                    }
                    CountFive++;
                }
            }
            catch
            {
                MessageBox.Show("Spreadsheet was not created!");
            }
            ProgressBar(65);
            label82.Text = "Creating File...";
            // Auto Size Sheet One
            for (int t = 0; t < sheet.ColumnCount; t++)
            {
                sheet.AutoSizeColumn(t);
            }
            for (int t = 0; t < sheet.RowCount; t++)
            {
                sheet.AutoSizeRow(t);
            }

            for (int t = 0; t < sheetTwo.ColumnCount; t++)
            {
                sheetTwo.AutoSizeColumn(t);
            }
            for (int t = 0; t < sheetTwo.RowCount; t++)
            {
                sheetTwo.AutoSizeRow(t);
            }

            for (int t = 0; t < sheetTwo.ColumnCount; t++)
            {
                sheetTwo.AutoSizeColumn(t);
            }
            for (int t = 0; t < sheetTwo.RowCount; t++)
            {
                sheetTwo.AutoSizeRow(t);
            }

            for (int t = 0; t < sheetFour.ColumnCount; t++)
            {
                sheetFour.AutoSizeColumn(t);
            }
            for (int t = 0; t < sheetFour.RowCount; t++)
            {
                sheetFour.AutoSizeRow(t);
            }
            for (int t = 0; t < sheetFive.ColumnCount; t++)
            {
                sheetFive.AutoSizeColumn(t);
            }
            for (int t = 0; t < sheetFive.RowCount; t++)
            {
                sheetFive.AutoSizeRow(t);
            }
            // Save Created Worksheetif (Globals.switchHit == true)
            if (Globals.switchHit == true)
            {
                workbook.SaveAs("Budget Basic - " + comboBox8.Text + ".xlsx");
            }
            else
            {
                workbook.SaveAs("Budget Basic.xlsx");
            }
            ProgressBar(75);
            label82.Text = "Creating File....";
            // Format Spreadsheet
            FormatSpread();
            ProgressBar(100);
            // Open File Location
            Process.Start("explorer.exe", ".");
            label82.Text = "File Created";
            if (Globals.switchHit == true)
            {
                MessageBox.Show("Spreadsheets are now created!");
            }
            else
            {
                MessageBox.Show("Spreadsheet is now created!");
            }
            ProgressBar(0);
        }
        public void FormatSpread()
        {
            WorkBook workBook = new WorkBook();
            if (Globals.switchHit == true)
            {
                workBook = WorkBook.Load("Budget Basic - " + comboBox8.Text + ".xlsx");
            }
            else
            {
                workBook = WorkBook.Load("Budget Basic.xlsx");
            }
            for (int i = 0; i < 5; i++)
            {
                WorkSheet workSheet = workBook.WorkSheets[i];                
                // Create conditional formatting rule
                var rule = workSheet.ConditionalFormatting.CreateConditionalFormattingRule(ComparisonOperator.GreaterThanOrEqual, "0");
                // Set style options
                //rule.FontFormatting.IsBold = true;
                rule.FontFormatting.FontColor = "#000000";
                rule.BorderFormatting.TopBorderType = BorderType.Thin;
                rule.BorderFormatting.TopBorderColor = "#000000";
                rule.BorderFormatting.BottomBorderType = BorderType.Thin;
                rule.BorderFormatting.BottomBorderColor = "#000000";
                rule.BorderFormatting.LeftBorderType = BorderType.Thin;
                rule.BorderFormatting.LeftBorderColor = "#000000";
                rule.BorderFormatting.RightBorderType = BorderType.Thin;
                rule.BorderFormatting.RightBorderColor = "#000000";
                rule.PatternFormatting.BackgroundColor = "#4DFF00";
                workSheet.FormatString = "0.00";
                
                // Apply formatting on specified region
                workSheet.ConditionalFormatting.AddConditionalFormatting("B1:" + workSheet.RowCount, rule);
                
            }
            for (int i = 0; i < 5; i++)
            {
                WorkSheet workSheet = workBook.WorkSheets[i];

                // Create conditional formatting rule
                var rule = workSheet.ConditionalFormatting.CreateConditionalFormattingRule(ComparisonOperator.GreaterThanOrEqual, "0");
                // Set style options
                //rule.FontFormatting.IsBold = true;
                rule.FontFormatting.FontColor = "#000000";
                rule.BorderFormatting.TopBorderType = BorderType.Thin;
                rule.BorderFormatting.TopBorderColor = "#000000";
                rule.BorderFormatting.BottomBorderType = BorderType.Thin;
                rule.BorderFormatting.BottomBorderColor = "#000000";
                rule.BorderFormatting.LeftBorderType = BorderType.Thin;
                rule.BorderFormatting.LeftBorderColor = "#000000";
                rule.BorderFormatting.RightBorderType = BorderType.Thin;
                rule.BorderFormatting.RightBorderColor = "#000000";
                rule.PatternFormatting.BackgroundColor = "#4DFF00";
                workSheet.FormatString = "0";
                // Apply formatting on specified region
                workSheet.ConditionalFormatting.AddConditionalFormatting("A1:" + workSheet.RowCount, rule);
                if (Globals.switchHit == true)
                {
                    workBook.SaveAs("Budget Basic - " + comboBox8.Text + ".xlsx");
                }
                else
                {
                    workBook.SaveAs("Budget Basic.xlsx");
                }
            }
        }
        public void PopulateDropMenus(ComboBox o)
        {
            // Run database connection
            using (SqlConnection dropDownConn = new SqlConnection(Globals.connectionString))
            {
                dropDownConn.Open();
                // Run SQL statement
                SqlCommand cmm = new SqlCommand(Globals.firstSelect, dropDownConn);
                // Read the results of statement and add all users into combobox
                using (SqlDataReader reader = cmm.ExecuteReader())
                {
                    // Clear out combobox to avoid duplicates
                    o.Items.Clear();
                    // Populate combobox with updated material
                    while (reader.Read())
                    {
                        Globals.first = reader.GetString(0).Trim();
                        Globals.last = reader.GetString(1).Trim();
                        o.Items.Add(Globals.first + " " + Globals.last);
                    }
                }
                // Close Current Connection
                dropDownConn.Close();
            }
        }
        public void IdChecker(ComboBox o, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5)
        {
            if (Globals.bypass == false)
            {
                try
                {
                    // Run database connection
                    using (SqlConnection con = new SqlConnection(Globals.connectionString))
                    {
                        // Search for ID from selected user in ComboBox
                        using (SqlCommand cmd = new SqlCommand(Globals.idNameSelect))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            string[] splitName = o.Text.Split(' ');
                            Globals.splitText = splitName[0];
                            cmd.Parameters.AddWithValue("@name", Globals.splitText);
                            Globals.currentUser = o.Text.ToString().Trim();

                            // Insert the ID from People Database
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                sdr.Read();
                                t1.Text = sdr["Id"].ToString().Trim();
                            }
                            con.Close();
                            Globals.currentUserId = t1.Text;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                // Attempt to populate fields from Money Database
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", t1.Text);
                    // Create a Message Box that allows users to enter pass code
                    Globals.boxAnswer = MessageBoard(Globals.dialogOne, Globals.dialogTwo, InputBox.Icon.Question, InputBox.Type.TextBox);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        {
                            //if (InputBox.ResultValue.ToString().Trim() == sdr["Pass"].ToString().Trim().Trim())
                            if (Globals.boxAnswer == sdr["Pass"].ToString().Trim().Trim())
                            {
                                t2.Text = sdr["Donation"].ToString().Trim().Trim();
                                t3.Text = sdr["Savings"].ToString().Trim().Trim();
                                t4.Text = sdr["GOKF"].ToString().Trim().Trim();
                                t5.Text = sdr["Spending"].ToString().Trim().Trim();
                                Globals.passChecker = true;
                            }
                            else
                            {
                                t2.Text = ("");
                                t3.Text = ("");
                                t4.Text = ("");
                                t5.Text = ("");
                                MessageBox.Show("Incorrect Pass Code");
                            }
                        }
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
            else
            {
                o.Text = Globals.currentUser;
                t1.Text = Globals.currentUserId;
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", t1.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        {
                            t2.Text = sdr["Donation"].ToString().Trim().Trim();
                            t3.Text = sdr["Savings"].ToString().Trim().Trim();
                            t4.Text = sdr["GOKF"].ToString().Trim().Trim();
                            t5.Text = sdr["Spending"].ToString().Trim().Trim();
                            Globals.passChecker = true;
                        }
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
        }
        public void DepoInfo(TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", t1.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    t2.Text = sdr["Donation"].ToString().Trim().Trim();
                    t3.Text = sdr["Savings"].ToString().Trim().Trim();
                    t4.Text = sdr["GOKF"].ToString().Trim().Trim();
                    t5.Text = sdr["Spending"].ToString().Trim().Trim();
                    t2.BackColor = System.Drawing.Color.Green;
                    t3.BackColor = System.Drawing.Color.Green;
                    t4.BackColor = System.Drawing.Color.Green;
                    t5.BackColor = System.Drawing.Color.Green;
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        public void SaveInfo()
        {
            // Attempt to populate fields from Money Database
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox65.Text = sdr["SaveOne"].ToString().Trim().Trim();
                    textBox62.Text = sdr["SaveTwo"].ToString().Trim().Trim();
                    textBox64.Text = sdr["SaveThree"].ToString().Trim().Trim();
                    textBox5.Text = sdr["SaveFour"].ToString().Trim().Trim();
                    textBox63.Text = sdr["SaveFive"].ToString().Trim().Trim();
                    textBox4.Text = sdr["SaveSix"].ToString().Trim().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    button9.Text = sdr["ItemOne"].ToString().Trim().Trim();
                    button10.Text = sdr["ItemTwo"].ToString().Trim().Trim();
                    button12.Text = sdr["ItemThree"].ToString().Trim().Trim();
                    button11.Text = sdr["ItemFour"].ToString().Trim().Trim();
                    button14.Text = sdr["ItemFive"].ToString().Trim().Trim();
                    button13.Text = sdr["ItemSix"].ToString().Trim().Trim();
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        public double ExpCalc()
        {
            double answer = double.Parse(textBox35.Text) + double.Parse(textBox36.Text) + double.Parse(textBox37.Text)
                            + double.Parse(textBox38.Text) + double.Parse(textBox39.Text) + double.Parse(textBox40.Text) + double.Parse(textBox41.Text)
                            + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text) + double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
                             + double.Parse(textBox21.Text) + double.Parse(textBox22.Text) + double.Parse(textBox23.Text) + double.Parse(textBox24.Text)
                              + double.Parse(textBox25.Text) + double.Parse(textBox26.Text) + double.Parse(textBox27.Text);
            return answer;
        }
        public void DelUser()
        {
            // Delete user from People Database                        
            SqlConnection connOne = new SqlConnection(Globals.connectionString);
            connOne.Open();
            SqlCommand cmdOne = new SqlCommand(Globals.sqlStatement, connOne);
            cmdOne.Parameters.AddWithValue("@id", "" + textBox59.Text + "");
            cmdOne.CommandType = CommandType.Text;
            cmdOne.ExecuteNonQuery();
            connOne.Close();
        }
        private string MessageBoard(string first, string second, InputBox.Icon icons, InputBox.Type type)
        {
            string returnAnswer;

            // Create a Message Box that allows users to enter password
            InputBox.SetLanguage(InputBox.Language.English);
            DialogResult res = InputBox.ShowDialog(first,
            second,   //Text message (mandatory), Title (optional)
                icons, //Set icon type (default info)
                InputBox.Buttons.Ok, //Set buttons (default ok)
                type, //Set type (default nothing)
                new string[] { "Item1", "Item2", "Item3" }, //String field as ComboBox items (default null)
                true, //Set visible in taskbar (default false)
                new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold)); //Set font (default by system)
            returnAnswer = InputBox.ResultValue.Trim();

            return returnAnswer;
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Contains("@") && textBox3.Text.Length == 4)
            {
                try
                {
                    // Setup user with new People Fields in Database
                    Globals.sqlStatement = "INSERT INTO People(First,Last,Email,Address1,Address2,City,State,Zip) Values(@firstName,@lastName,@email,@address1,@address2,@city,@state,@zip)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@firstName", SqlDbType.Char, 30));
                    cmd.Parameters.Add(new SqlParameter("@lastName", SqlDbType.Char, 30));
                    cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.Char, 50));
                    cmd.Parameters.Add(new SqlParameter("@address1", SqlDbType.Char, 50));
                    cmd.Parameters.Add(new SqlParameter("@address2", SqlDbType.Char, 50));
                    cmd.Parameters.Add(new SqlParameter("@city", SqlDbType.Char, 50));
                    cmd.Parameters.Add(new SqlParameter("@state", SqlDbType.Char, 2));
                    cmd.Parameters.Add(new SqlParameter("@zip", SqlDbType.Char, 10));
                    // Set user inputted values within the database
                    cmd.Parameters["@firstname"].Value = textBox11.Text.Trim();
                    cmd.Parameters["@lastname"].Value = textBox12.Text.Trim();
                    cmd.Parameters["@email"].Value = textBox13.Text.Trim();
                    cmd.Parameters["@address1"].Value = textBox14.Text.Trim();
                    cmd.Parameters["@address2"].Value = textBox15.Text.Trim();
                    cmd.Parameters["@city"].Value = textBox16.Text.Trim();
                    cmd.Parameters["@state"].Value = stateBox1.Text.Trim();
                    cmd.Parameters["@zip"].Value = textBox17.Text.Trim();
                    // Open Database
                    cn.Open();
                    if (textBox13.Text.Contains("@"))
                    {
                        // Run SQL Statement
                        cmd.ExecuteNonQuery();
                        // Close Database
                        cn.Close();
                    }
                    else
                    {
                        // Close Database
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    // Setup user with new Money Fields in Database
                    Globals.sqlStatement = "INSERT INTO Money(Donation,Savings,GOKF,Spending,Pass) Values(@donate,@save,@gokf,@spend,@pass)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@donate", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@save", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@gokf", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@spend", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.Char, 4));
                    // Set 0 for the values within the database
                    cmd.Parameters["@donate"].Value = "0.00";
                    cmd.Parameters["@save"].Value = "0.00";
                    cmd.Parameters["@gokf"].Value = "0.00";
                    cmd.Parameters["@spend"].Value = "0.00";
                    cmd.Parameters["@pass"].Value = textBox3.Text;
                    // Open Database
                    cn.Open();
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch
                {
                    MessageBox.Show("No Money Input");
                }
                try
                {
                    // Setup user with new Money Fields in Database
                    Globals.sqlStatement = "INSERT INTO LongTermTitles(ItemOne,ItemTwo,ItemThree,ItemFour,ItemFive,ItemSix) Values(@itemOne,@itemTwo,@itemThree,@itemFour,@itemFive,@itemSix)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@itemOne", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemTwo", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemThree", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemFour", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemFive", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemSix", SqlDbType.Char, 25));
                    // Set 0 for the values within the database
                    cmd.Parameters["@itemOne"].Value = "SetItemOne";
                    cmd.Parameters["@itemTwo"].Value = "SetItemTwo";
                    cmd.Parameters["@itemThree"].Value = "SetItemThree";
                    cmd.Parameters["@itemFour"].Value = "SetItemFour";
                    cmd.Parameters["@itemFive"].Value = "SetItemFive";
                    cmd.Parameters["@itemSix"].Value = "SetItemSix";
                    // Open Database
                    cn.Open();
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    // Close Database
                    cn.Close();
                }
                catch
                {
                    MessageBox.Show("No Title Inputs");
                }
                try
                {
                    // Setup user with new Money Fields in Database
                    Globals.sqlStatement = "INSERT INTO LongTermSaves(SaveOne,SaveTwo,SaveThree,SaveFour,SaveFive,SaveSix) Values(@saveOne,@saveTwo,@saveThree,@saveFour,@saveFive,@saveSix)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@saveOne", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveTwo", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveThree", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveFour", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveFive", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveSix", SqlDbType.Float, 53));
                    // Set 0 for the values within the database
                    cmd.Parameters["@saveOne"].Value = "0.00";
                    cmd.Parameters["@saveTwo"].Value = "0.00";
                    cmd.Parameters["@saveThree"].Value = "0.00";
                    cmd.Parameters["@saveFour"].Value = "0.00";
                    cmd.Parameters["@saveFive"].Value = "0.00";
                    cmd.Parameters["@saveSix"].Value = "0.00";
                    // Open Database
                    cn.Open();
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    // Close Database
                    cn.Close();
                }
                catch
                {
                    MessageBox.Show("No Money Title Inputs");
                }
                try
                {
                    // Setup user with new Money Fields in Database
                    Globals.sqlStatement = "INSERT INTO MonthlyCosts(MonthlyOne,MonthlyTwo,MonthlyThree,MonthlyFour,MonthlyFive,MonthlySix," +
                        "MonthlySeven,MonthlyEight,MonthlyNine,MonthlyTen,MonthlyEleven,MonthlyTwelve,MonthlyThirteen,MonthlyFourteen," +
                        "MonthlyFifteen,MonthlySixteen,MonthlySeventeen,MonthlyEighteen,MonthlyNineteen,MonthlyTwenty) " +
                        "Values(@mOne,@mTwo,@mThree,@mFour,@mFive,@mSix,@mSeven,@mEight,@mNine,@mTen,@mEleven,@mTwelve,@mThirteen," +
                        "@mFourteen,@mFifteen,@mSixteen,@mSeventeen,@mEighteen,@mNineteen,@mTwenty)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@mOne", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mTwo", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mThree", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mFour", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mFive", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mSix", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mSeven", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mEight", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mNine", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mTen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mEleven", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mTwelve", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mThirteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mFourteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mFifteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mSixteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mSeventeen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mEighteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mNineteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mTwenty", SqlDbType.Float, 53));
                    // Set 0 for the values within the database
                    cmd.Parameters["@mOne"].Value = "0.00";
                    cmd.Parameters["@mTwo"].Value = "0.00";
                    cmd.Parameters["@mThree"].Value = "0.00";
                    cmd.Parameters["@mFour"].Value = "0.00";
                    cmd.Parameters["@mFive"].Value = "0.00";
                    cmd.Parameters["@mSix"].Value = "0.00";
                    cmd.Parameters["@mSeven"].Value = "0.00";
                    cmd.Parameters["@mEight"].Value = "0.00";
                    cmd.Parameters["@mNine"].Value = "0.00";
                    cmd.Parameters["@mTen"].Value = "0.00";
                    cmd.Parameters["@mEleven"].Value = "0.00";
                    cmd.Parameters["@mTwelve"].Value = "0.00";
                    cmd.Parameters["@mThirteen"].Value = "0.00";
                    cmd.Parameters["@mFourteen"].Value = "0.00";
                    cmd.Parameters["@mFifteen"].Value = "0.00";
                    cmd.Parameters["@mSixteen"].Value = "0.00";
                    cmd.Parameters["@mSeventeen"].Value = "0.00";
                    cmd.Parameters["@mEighteen"].Value = "0.00";
                    cmd.Parameters["@mNineteen"].Value = "0.00";
                    cmd.Parameters["@mTwenty"].Value = "0.00";
                    // Open Database
                    cn.Open();
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    // Close Database
                    cn.Close();
                    MessageBox.Show("User Account Created");
                }
                catch
                {
                    MessageBox.Show("No Costs Inputted");
                }
            }
            else
            {
                if (!textBox13.Text.Contains("@"))
                {
                    MessageBox.Show("        Invalid Email Address, \n                 Try Again.");
                }
                else
                {
                    MessageBox.Show("Passcode must be 4 characters in length.");
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            double input = 0;
            // Check if user is selected prior to calculations
            if (textBox6.Text != "" && comboBox6.Text != "")
            {
                // Initial Input Calculations
                try
                {
                    input = double.Parse(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("Please Enter Only Numbers");
                }
                // Check to see if user's input is not a negative
                if (input < 0)
                {
                    MessageBox.Show("Income must be a positive number");
                }
                else
                {
                    if (radioButton1.Checked != false || radioButton2.Checked != false)
                    {
                        // Check to see if God Only Knows Fund has reached or will reach set cap.
                        double checkAmount = double.Parse(textBox9.Text);
                        double preCheck = double.Parse(textBox9.Text) + (input * 0.25);

                        // Calculate Remaining Sections
                        textBox2.Text = Decimal.Round((decimal)(input * 0.10), 2).ToString().Trim();

                        // If God Only Knows Fund is already at set cap, take remainder and add it to Spending Section*
                        if (checkAmount >= double.Parse(comboBox6.Text) && radioButton2.Checked)
                        {
                            savingsBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString().Trim();
                            GOKFBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString().Trim();
                            double remainder = double.Parse(GOKFBox.Text);
                            GOKFBox.Text = 0.00.ToString().Trim();
                            spendingBox.Text = Decimal.Round((decimal)((input * 0.40) + remainder), 2).ToString().Trim();
                        }
                        // If God Only Knows Fund is already at set cap, take remainder and add it to Saving Section*
                        else if (checkAmount >= double.Parse(comboBox6.Text) && radioButton1.Checked)
                        {
                            GOKFBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString().Trim();
                            double remainder = double.Parse(GOKFBox.Text);
                            savingsBox.Text = Decimal.Round((decimal)((input * 0.25) + remainder), 2).ToString().Trim();
                            GOKFBox.Text = 0.00.ToString().Trim();
                            spendingBox.Text = Decimal.Round((decimal)((input * 0.40)), 2).ToString().Trim();
                        }
                        // If God Only Knows Fund deposit reaches set cap, take remainder and add it to Spending Section*
                        else if (preCheck >= double.Parse(comboBox6.Text) && radioButton2.Checked)
                        {
                            
                            savingsBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString().Trim();
                            GOKFBox.Text = (double.Parse(comboBox6.Text) - double.Parse(textBox9.Text)).ToString().Trim();
                            double remainder = (input * 0.25) - double.Parse(GOKFBox.Text);
                            spendingBox.Text = Decimal.Round((decimal)((input * 0.40) + remainder), 2).ToString().Trim();
                        }
                        // If God Only Knows Fund deposit reaches set cap, take remainder and add it to Spending Section*
                        else if (preCheck >= double.Parse(comboBox6.Text) && radioButton1.Checked)
                        {
                            double remainder = (input * 0.25) - double.Parse(GOKFBox.Text);
                            savingsBox.Text = Decimal.Round((decimal)((input * 0.25) + remainder), 2).ToString().Trim();
                            GOKFBox.Text = (double.Parse(comboBox6.Text) - double.Parse(textBox9.Text)).ToString().Trim();
                            spendingBox.Text = Decimal.Round((decimal)((input * 0.40)), 2).ToString().Trim();
                        }
                        // If neither calculation reaches the maximum amount of set cap in the GOKF, complete calulations without any changes.
                        else
                        {
                            savingsBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString().Trim();
                            GOKFBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString().Trim();
                            spendingBox.Text = Decimal.Round((decimal)(input * 0.40), 2).ToString().Trim();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select Radio Button to add remainder");
                    }
                }
            }
            // Alert user that they need to select an account prior to completing any calculations
            else
            {
                MessageBox.Show("Select User\nSet Cap God Only Knows Fund");
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Adding Fields Together?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Initiate SQL items for when the text is changed within the ComboBox
                try
                {
                    double donationCalc = double.Parse(textBox2.Text) + double.Parse(textBox7.Text);
                    double savingCalc = double.Parse(savingsBox.Text) + double.Parse(textBox8.Text);
                    double gokfCalc = double.Parse(GOKFBox.Text) + double.Parse(textBox9.Text);
                    double spendingCalc = double.Parse(spendingBox.Text) + double.Parse(textBox10.Text);

                    SqlConnection conn = new SqlConnection(Globals.connectionString);
                    conn.Open();

                    string updateQuery = "UPDATE Money SET Donation='" + donationCalc.ToString().Trim() + "',Savings='" + savingCalc.ToString().Trim() + "',GOKF='" + gokfCalc.ToString().Trim() + "',Spending='" + spendingCalc.ToString().Trim() + "' WHERE Id = " + textBox6.Text;
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                DepoInfo(textBox6, textBox7, textBox8, textBox9, textBox10);

            }
            else
            {
                MessageBox.Show("Action Cancelled");
            }
        }
        // Undo last transaction from Deposit
        private void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Undoing Last Transaction?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    double donationCalc = double.Parse(textBox7.Text) - double.Parse(textBox2.Text);
                    double savingCalc = double.Parse(textBox8.Text) - double.Parse(savingsBox.Text);
                    double gokfCalc = double.Parse(textBox9.Text) - double.Parse(GOKFBox.Text);
                    double spendingCalc = double.Parse(textBox10.Text) - double.Parse(spendingBox.Text);

                    SqlConnection conn = new SqlConnection(Globals.connectionString);
                    conn.Open();

                    string updateQuery = "UPDATE Money SET Donation='" + donationCalc.ToString().Trim() + "',Savings='" + savingCalc.ToString().Trim() + "',GOKF='" + gokfCalc.ToString().Trim() + "',Spending='" + spendingCalc.ToString().Trim() + "' WHERE Id = " + textBox6.Text;
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                DepoInfo(textBox6, textBox7, textBox8, textBox9, textBox10);
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected to do calculations
            if (textBox30.Text == "")
            {
                MessageBox.Show("Select A User.");
            }
            // User is available to complete calculations
            else
            {
                if (MessageBox.Show("Confirm Comparing Expenses to Income?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Combine all the expenses into a single variable.
                        double expensesCalc = ExpCalc();
                        // Main Expense Totals
                        double mainExpense = double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
                             + double.Parse(textBox21.Text) + double.Parse(textBox22.Text) + double.Parse(textBox23.Text) + double.Parse(textBox24.Text)
                              + double.Parse(textBox25.Text) + double.Parse(textBox26.Text) + double.Parse(textBox27.Text);
                        // Find the difference between what is available to what expenses are being used.
                        double differenceCalc = double.Parse(textBox34.Text) - expensesCalc;
                        // Display all expenses
                        textBox28.Text = expensesCalc.ToString().Trim();
                        textBox60.Text = mainExpense.ToString().Trim();
                        // Display the difference
                        if (differenceCalc < 0)
                        {
                            textBox29.BackColor = System.Drawing.Color.Black;
                            textBox29.ForeColor = System.Drawing.Color.Red;
                            textBox29.Text = differenceCalc.ToString().Trim();
                        }
                        else
                        {
                            textBox29.BackColor = System.Drawing.Color.Green;
                            textBox29.ForeColor = System.Drawing.Color.Black;
                            textBox29.Text = differenceCalc.ToString().Trim();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Calculations could not be performed");
                    }
                    try
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE MonthlyCosts SET MonthlyOne='" + textBox18.Text + "',MonthlyTwo='"
                            + textBox19.Text + "',MonthlyThree='" + textBox20.Text + "',MonthlyFour='" + textBox21.Text
                            + "',MonthlyFive='" + textBox22.Text + "',MonthlySix='" + textBox23.Text + "',MonthlySeven='"
                            + textBox24.Text + "',MonthlyEight='" + textBox25.Text + "',MonthlyNine='" + textBox26.Text
                            + "',MonthlyTen='" + textBox27.Text + "' WHERE Id = " + textBox30.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No ConnectionThere");
                    }

                }
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected to do calculations
            if (textBox47.Text == "")
            {
                MessageBox.Show("Select A User.");
            }
            // User is available to complete calculations
            else
            {
                if (MessageBox.Show("Confirm Comparing Expenses to Income?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Combine all the expenses into a single variable.
                        double expensesCalc = ExpCalc();
                        // Additional Expenses Total
                        double additionalExpenses = double.Parse(textBox35.Text) + double.Parse(textBox36.Text) + double.Parse(textBox37.Text)
                            + double.Parse(textBox38.Text) + double.Parse(textBox39.Text) + double.Parse(textBox40.Text) + double.Parse(textBox41.Text)
                            + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text);
                        // Find the difference between what is available to what expenses are being used.
                        double differenceCalc = double.Parse(textBox51.Text) - expensesCalc;
                        // Display all expenses
                        textBox45.Text = expensesCalc.ToString().Trim();
                        textBox61.Text = additionalExpenses.ToString().Trim();
                        // Display the difference
                        if (differenceCalc < 0)
                        {
                            textBox46.BackColor = System.Drawing.Color.Black;
                            textBox46.ForeColor = System.Drawing.Color.Red;
                            textBox46.Text = differenceCalc.ToString().Trim();
                        }
                        else
                        {
                            textBox46.BackColor = System.Drawing.Color.Green;
                            textBox46.Text = differenceCalc.ToString().Trim();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Calculations could not be performed");
                    }
                    try
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE MonthlyCosts SET MonthlyEleven='" + textBox35.Text + "',MonthlyTwelve='"
                            + textBox36.Text + "',MonthlyThirteen='" + textBox37.Text + "',MonthlyFourteen='" + textBox38.Text
                            + "',MonthlyFifteen='" + textBox39.Text + "',MonthlySixteen='" + textBox40.Text + "',MonthlySeventeen='"
                            + textBox41.Text + "',MonthlyEighteen='" + textBox42.Text + "',MonthlyNineteen='" + textBox43.Text
                            + "',MonthlyTwenty='" + textBox44.Text + "' WHERE Id = " + textBox47.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No ConnectionThere");
                    }

                }
            }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Updaing User?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Globals.connectionString);
                    conn.Open();

                    Globals.sqlStatement = "UPDATE People SET First='" + textBox52.Text.Trim() + "',Last='" + textBox53.Text.Trim() +
                        "',Email='" + textBox54.Text.Trim() + "',Address1='" + textBox55.Text.Trim() + "',Address2='" + textBox56.Text.Trim() +
                        "',City='" + textBox57.Text.Trim() + "',State='" + comboBox4.Text.Trim() + "',Zip='" + textBox58.Text.Trim() + "' WHERE Id = " + textBox59.Text;
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                // Attempt to populate fields from Money Database
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.peopleSelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox59.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox52.Text = sdr["First"].ToString().Trim().Trim();
                        textBox53.Text = sdr["Last"].ToString().Trim().Trim();
                        textBox54.Text = sdr["Email"].ToString().Trim().Trim();
                        textBox55.Text = sdr["Address1"].ToString().Trim().Trim();
                        textBox56.Text = sdr["Address2"].ToString().Trim().Trim();
                        textBox57.Text = sdr["City"].ToString().Trim().Trim();
                        comboBox4.Text = sdr["State"].ToString().Trim().Trim();
                        textBox58.Text = sdr["Zip"].ToString().Trim().Trim();
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox59.Text);
                // Create a Message Box that allows users to enter pass code
                Globals.boxAnswer = MessageBoard(Globals.dialogOne, Globals.dialogTwo, InputBox.Icon.Question, InputBox.Type.TextBox);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    if (Globals.boxAnswer.ToString().Trim() == sdr["Pass"].ToString().Trim().Trim())
                    {
                        // Delete user from People Database
                        Globals.sqlStatement = "DELETE FROM People WHERE Id=@id";
                        DelUser();
                        // Delete user from People Database
                        Globals.sqlStatement = "DELETE FROM MonthlyCosts WHERE Id=@id";
                        DelUser();
                        // Delete user from Money Database
                        Globals.sqlStatement = "DELETE FROM Money WHERE Id=@id";
                        DelUser();
                        // Delete user from LongTermTitles Database
                        Globals.sqlStatement = "DELETE LongTermTitles WHERE Id=@id";
                        DelUser();
                        // Delete user from LongTermSaves Database
                        Globals.sqlStatement = "DELETE FROM LongTermSaves WHERE Id=@id";
                        DelUser();
                        MessageBox.Show("User Successfully Deleted");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                    }
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected to do calculations
            if (textBox66.Text == "")
            {
                MessageBox.Show("Select A User.");
            }
            // User is available to complete calculations
            else
            {
                if (MessageBox.Show("Confirm Comparing Expenses to Income?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Combine all the expenses into a single variable.
                        double expensesCalc = double.Parse(textBox65.Text) + double.Parse(textBox62.Text) + double.Parse(textBox64.Text)
                            + double.Parse(textBox5.Text) + double.Parse(textBox63.Text) + double.Parse(textBox4.Text);
                        // Find the difference between what is available to what expenses are being used.
                        double differenceCalc = double.Parse(textBox69.Text) - expensesCalc;
                        // Display all expenses
                        textBox73.Text = expensesCalc.ToString().Trim();
                        // Display the difference
                        if (differenceCalc < 0)
                        {
                            textBox72.BackColor = System.Drawing.Color.Black;
                            textBox72.ForeColor = System.Drawing.Color.Red;
                            textBox72.Text = differenceCalc.ToString().Trim();
                        }
                        else
                        {
                            textBox72.BackColor = System.Drawing.Color.Green;
                            textBox72.Text = differenceCalc.ToString().Trim();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Calculations could not be performed");
                    }
                    try
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE LongTermSaves SET SaveOne='" + textBox65.Text + "',SaveTwo='" + textBox62.Text + "',SaveThree='" + textBox64.Text + "',SaveFour='" + textBox5.Text + "',SaveFive='" + textBox63.Text + "',SaveSix='" + textBox4.Text + "'  WHERE Id = " + textBox66.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No Connection");
                    }

                }
            }
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.dialogThree, Globals.dialogFour, InputBox.Icon.Information, InputBox.Type.TextBoxTitle);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemOne='" + Globals.boxAnswer.Trim().ToString().Trim() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            SaveInfo();
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.dialogThree, Globals.dialogFour, InputBox.Icon.Information, InputBox.Type.TextBoxTitle);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemTwo='" + Globals.boxAnswer.Trim().ToString().Trim() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            SaveInfo();
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.dialogThree, Globals.dialogFour, InputBox.Icon.Information, InputBox.Type.TextBoxTitle);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemFour='" + Globals.boxAnswer.Trim().ToString().Trim() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            SaveInfo();
        }
        private void Button12_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.dialogThree, Globals.dialogFour, InputBox.Icon.Information, InputBox.Type.TextBoxTitle);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemThree='" + Globals.boxAnswer.Trim().ToString().Trim() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            SaveInfo();
        }
        private void Button13_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.dialogThree, Globals.dialogFour, InputBox.Icon.Information, InputBox.Type.TextBoxTitle);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemSix='" + Globals.boxAnswer.Trim().ToString().Trim() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            SaveInfo();
        }
        private void Button14_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.dialogThree, Globals.dialogFour, InputBox.Icon.Information, InputBox.Type.TextBoxTitle);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemFive='" + Globals.boxAnswer.Trim().ToString().Trim() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            SaveInfo();
        }
        private void Button15_Click(object sender, EventArgs e)
        {
            if (textBox69.Text != "" && textBox67.Text != "")
            {
                try
                {
                    double savingAddition = double.Parse(textBox71.Text) + double.Parse(textBox69.Text);
                    double spendingSubtract = double.Parse(textBox67.Text) - double.Parse(textBox71.Text);
                    if (spendingSubtract < 0)
                    {
                        MessageBox.Show("Not enough funds to complete transfer.");
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE Money SET Savings='" + savingAddition.ToString().Trim() + "',Spending='" + spendingSubtract.ToString().Trim() + "' WHERE Id = " + textBox66.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                if (Globals.passChecker == true && Globals.currentUser != "")
                {
                    Globals.bypass = true;
                    ComboBoxTextChangeSeven(sender, e);
                }
                else
                {
                    Globals.bypass = false;
                }
            }
            else
            {
                MessageBox.Show("Select User");
            }
        }
        private void Button16_Click(object sender, EventArgs e)
        {
            if (textBox69.Text != "" && textBox67.Text != "")
            {
                try
                {
                    double spendingAddition = double.Parse(textBox71.Text) + double.Parse(textBox67.Text);
                    double savingSubtract = double.Parse(textBox69.Text) - double.Parse(textBox71.Text);
                    if (savingSubtract < 0)
                    {
                        MessageBox.Show("Not enough funds to complete transfer.");
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE Money SET Savings='" + savingSubtract.ToString().Trim() + "',Spending='" + spendingAddition.ToString().Trim() + "' WHERE Id = " + textBox66.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        
                    }
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                if (Globals.passChecker == true && Globals.currentUser != "")
                {
                    Globals.bypass = true;
                    ComboBoxTextChangeSeven(sender, e);
                }
                else
                {
                    Globals.bypass = false;
                }
            }
            else
            {
                MessageBox.Show("Select User");
            }
        }
        // Check to see users available in database
        private void ComboBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                PopulateDropMenus(comboBox1);
            }
            else
            {
                comboBox1.Items.Clear();
                Globals.bypass = false;
                PopulateDropMenus(comboBox1);
            }
        }
        private void ComboBoxTextChange(object sender, EventArgs e)
        {
            // Attempt to determine the User and populate fields from totals
            IdChecker(comboBox1, textBox6, textBox7, textBox8, textBox9, textBox10);
        }
        // Check to see users available in database
        private void ComboBox2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                PopulateDropMenus(comboBox2);
            }
            else
            {
                Globals.bypass = false;
                comboBox2.Items.Clear();
                PopulateDropMenus(comboBox2);
            }
        }
        private void ComboBoxTextChangeTwo(object sender, EventArgs e)
        {
            IdChecker(comboBox2, textBox30, textBox31, textBox32, textBox33, textBox34);

            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.monthSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox30.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox18.Text = sdr["MonthlyOne"].ToString().Trim().Trim();
                    textBox19.Text = sdr["MonthlyTwo"].ToString().Trim().Trim();
                    textBox20.Text = sdr["MonthlyThree"].ToString().Trim().Trim();
                    textBox21.Text = sdr["MonthlyFour"].ToString().Trim().Trim();
                    textBox22.Text = sdr["MonthlyFive"].ToString().Trim().Trim();
                    textBox23.Text = sdr["MonthlySix"].ToString().Trim().Trim();
                    textBox24.Text = sdr["MonthlySeven"].ToString().Trim().Trim();
                    textBox25.Text = sdr["MonthlyEight"].ToString().Trim().Trim();
                    textBox26.Text = sdr["MonthlyNine"].ToString().Trim().Trim();
                    textBox27.Text = sdr["MonthlyTen"].ToString().Trim().Trim();
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            try
            {
                // Combine all the expenses into a single variable.
                double expensesCalc = ExpCalc();
                // Main Expense Totals
                double mainExpense = double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
                        + double.Parse(textBox21.Text) + double.Parse(textBox22.Text) + double.Parse(textBox23.Text) + double.Parse(textBox24.Text)
                        + double.Parse(textBox25.Text) + double.Parse(textBox26.Text) + double.Parse(textBox27.Text);
                // Find the difference between what is available to what expenses are being used.
                double differenceCalc = double.Parse(textBox34.Text) - expensesCalc;
                // Display all expenses
                textBox28.Text = expensesCalc.ToString().Trim();
                textBox60.Text = mainExpense.ToString().Trim();
                // Display the difference
                if (differenceCalc < 0)
                {
                    textBox29.BackColor = System.Drawing.Color.Black;
                    textBox29.ForeColor = System.Drawing.Color.Red;
                    textBox29.Text = differenceCalc.ToString().Trim();
                }
                else
                {
                    textBox29.BackColor = System.Drawing.Color.Green;
                    textBox29.ForeColor = System.Drawing.Color.Black;
                    textBox29.Text = differenceCalc.ToString().Trim();
                }
            }
            catch
            {
                MessageBox.Show("Calculations could not be performed");
            }
        }
        private void ComboBox3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                PopulateDropMenus(comboBox3);
            }
            else
            {
                Globals.bypass = false;
                comboBox3.Items.Clear();
                PopulateDropMenus(comboBox3);
            }
        }
        private void ComboBoxTextChangeThree(object sender, EventArgs e)
        {
            IdChecker(comboBox3, textBox47, textBox48, textBox49, textBox50, textBox51);

            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.monthSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox47.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox35.Text = sdr["MonthlyOne"].ToString().Trim().Trim();
                    textBox36.Text = sdr["MonthlyTwo"].ToString().Trim().Trim();
                    textBox37.Text = sdr["MonthlyThree"].ToString().Trim().Trim();
                    textBox38.Text = sdr["MonthlyFour"].ToString().Trim().Trim();
                    textBox39.Text = sdr["MonthlyFive"].ToString().Trim().Trim();
                    textBox40.Text = sdr["MonthlySix"].ToString().Trim().Trim();
                    textBox41.Text = sdr["MonthlySeven"].ToString().Trim().Trim();
                    textBox42.Text = sdr["MonthlyEight"].ToString().Trim().Trim();
                    textBox43.Text = sdr["MonthlyNine"].ToString().Trim().Trim();
                    textBox44.Text = sdr["MonthlyTen"].ToString().Trim().Trim();
                    textBox35.Text = sdr["MonthlyEleven"].ToString().Trim().Trim();
                    textBox36.Text = sdr["MonthlyTwelve"].ToString().Trim().Trim();
                    textBox37.Text = sdr["MonthlyThirteen"].ToString().Trim().Trim();
                    textBox38.Text = sdr["MonthlyFourteen"].ToString().Trim().Trim();
                    textBox39.Text = sdr["MonthlyFifteen"].ToString().Trim().Trim();
                    textBox40.Text = sdr["MonthlySixteen"].ToString().Trim().Trim();
                    textBox41.Text = sdr["MonthlySeventeen"].ToString().Trim().Trim();
                    textBox42.Text = sdr["MonthlyEighteen"].ToString().Trim().Trim();
                    textBox43.Text = sdr["MonthlyNineteen"].ToString().Trim().Trim();
                    textBox44.Text = sdr["MonthlyTwenty"].ToString().Trim().Trim();
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }

            try
            {
                // Combine all the expenses into a single variable.
                double expensesCalc = ExpCalc();
                // Additional Expenses Total
                double additionalExpenses = double.Parse(textBox35.Text) + double.Parse(textBox36.Text) + double.Parse(textBox37.Text)
                    + double.Parse(textBox38.Text) + double.Parse(textBox39.Text) + double.Parse(textBox40.Text) + double.Parse(textBox41.Text)
                    + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text);
                // Find the difference between what is available to what expenses are being used.
                double differenceCalc = double.Parse(textBox51.Text) - expensesCalc;
                // Display all expenses
                textBox45.Text = expensesCalc.ToString().Trim();
                textBox61.Text = additionalExpenses.ToString().Trim();
                // Display the difference
                if (differenceCalc < 0)
                {
                    textBox46.BackColor = System.Drawing.Color.Black;
                    textBox46.ForeColor = System.Drawing.Color.Red;
                    textBox46.Text = differenceCalc.ToString().Trim();
                }
                else
                {
                    textBox46.BackColor = System.Drawing.Color.Green;
                    textBox46.ForeColor = System.Drawing.Color.Black;
                    textBox46.Text = differenceCalc.ToString().Trim();
                }
            }
            catch
            {
                MessageBox.Show("Calculations could not be performed");
            }

        }
        private void ComboBoxFive_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "")
            {
                PopulateDropMenus(comboBox5);
            }
            else
            {
                Globals.bypass = false;
                comboBox5.Items.Clear();
                PopulateDropMenus(comboBox5);
            }
        }
        private void ComboBoxTextChangeFive(object sender, EventArgs e)
        {
            // Attempt to determine the User and populate fields from totals
            try
            {
                // Run database connection
                using (SqlConnection con = new SqlConnection(Globals.connectionString))
                {
                    // Search for ID from selected user in ComboBox
                    using (SqlCommand cmd = new SqlCommand(Globals.idNameSelect))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        string[] splitName = comboBox5.Text.Split(' ');
                        Globals.splitText = splitName[0];
                        cmd.Parameters.AddWithValue("@name", Globals.splitText);
                        // Insert the ID from People Database
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            textBox59.Text = sdr["Id"].ToString().Trim().Trim();
                            con.Close();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.peopleSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox59.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox52.Text = sdr["First"].ToString().Trim().Trim();
                    textBox53.Text = sdr["Last"].ToString().Trim().Trim();
                    textBox54.Text = sdr["Email"].ToString().Trim().Trim();
                    textBox55.Text = sdr["Address1"].ToString().Trim().Trim();
                    textBox56.Text = sdr["Address2"].ToString().Trim().Trim();
                    textBox57.Text = sdr["City"].ToString().Trim().Trim();
                    comboBox4.Text = sdr["State"].ToString().Trim().Trim();
                    textBox58.Text = sdr["Zip"].ToString().Trim().Trim();
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        private void ChangeTabs(object sender, EventArgs e)
        {
            // Combine all the expenses into a single variable.
            double expensesCalc = ExpCalc();
            // Display all expenses
            textBox45.Text = expensesCalc.ToString().Trim();
            textBox28.Text = expensesCalc.ToString().Trim();
        }
        private void ComboBox7_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {
                PopulateDropMenus(comboBox7);
            }
            else
            {
                Globals.bypass = false;
                comboBox7.Items.Clear();
                PopulateDropMenus(comboBox7);
            }
        }
        private void ComboBoxTextChangeSeven(object sender, EventArgs e)
        {
            IdChecker(comboBox7, textBox66, textBox70, textBox69, textBox68, textBox67);
            // Attempt to populate fields from Money Database
            SaveInfo();
        }
        private void comboBox8_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text == "")
            {
                PopulateDropMenus(comboBox8);
            }
            else
            {
                Globals.bypass = false;
                comboBox8.Items.Clear();
                PopulateDropMenus(comboBox8);
            }
        }

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
            IdChecker(comboBox8, textBox78, textBox77, textBox76, textBox75, textBox74);
        }
        private void TabPage2_Layout(object sender, LayoutEventArgs e)
        {

            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                ComboBoxTextChange(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }
        }
        private void TabPage3_Layout(object sender, LayoutEventArgs e)
        {
            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                ComboBoxTextChangeTwo(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }
        }
        private void tabPage4_Layout(object sender, LayoutEventArgs e)
        {
            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                ComboBoxTextChangeSeven(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }
        }
        private void TabPage5_Layout(object sender, LayoutEventArgs e)
        {
            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                ComboBoxTextChangeThree(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }
        }
        private void tabPage7_Layout(object sender, LayoutEventArgs e)
        {
            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                comboBox8_TextChanged(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }
        }
        private void TextBox71_MouseClick(object sender, MouseEventArgs e)
        {
            textBox71.Text = "";
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            label82.Text = "Creating File.";
            Globals.switchHit = false;
            Create_Excel_All(Globals.selectAllPeople, Globals.selectAllMonCo, Globals.selectAllMoney, Globals.selectAllLongTitles,
                Globals.selectAllLongSaves);
            label82.Text = "";
            ProgressBar(0);
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            if (textBox78.Text != "")
            {
                Globals.switchHit = true;
                label82.Text = "Creating File.";
                AdaptTemp(Globals.selectWherePeople + textBox78.Text, Globals.selectWhereMonCo + textBox78.Text,
                    Globals.selectWhereMoney + textBox78.Text, Globals.selectWhereLongTitles + textBox78.Text,
                    Globals.selectWhereLongSaves + textBox78.Text);
                Create_Excel_All(Globals.selectWherePeople + textBox78.Text, Globals.selectWhereMonCo + textBox78.Text,
                    Globals.selectWhereMoney + textBox78.Text, Globals.selectWhereLongTitles + textBox78.Text,
                    Globals.selectWhereLongSaves + textBox78.Text);
                label82.Text = "";
                ProgressBar(0);
            }
            else
            {
                MessageBox.Show("No User currently available");
            }
        }
    }
}
