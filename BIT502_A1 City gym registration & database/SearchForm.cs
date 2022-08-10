using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_1_prototype___sean
{
    public partial class SearchForm : Form
    {

        // Global Attributes
        int Member_ID;
        string First_Name;
        string Last_Name;
        string Address;
        int Phone_Number;
        string Payment_Frequency;
        Double Discount_Amount;
        Double Extra_Amount;
        Double Total_Amount;
        int Membership_Type_ID;
        string Duration;
        string baseBookingDetails;
        string bookingDetails;
        string membershipDetails;
        string membershipType;
        int baseCost;
        MemberFitnessDataSet.MemberRow T1;
        MemberFitnessDataSet.MembershipRow T2;
        MemberFitnessDataSet.Fitness_ClassRow T3;
        MemberFitnessDataSet.Class_BookingRow T4;


        public SearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu a = new MainMenu();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void class_BookingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.class_BookingBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.memberFitnessDataSet);

        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'memberFitnessDataSet.Membership' table. You can move, or remove it, as needed.
            this.membershipTableAdapter.Fill(this.memberFitnessDataSet.Membership);
            // TODO: This line of code loads data into the 'memberFitnessDataSet.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.memberFitnessDataSet.Member);
            // TODO: This line of code loads data into the 'memberFitnessDataSet.Fitness_Class' table. You can move, or remove it, as needed.
            this.fitness_ClassTableAdapter.Fill(this.memberFitnessDataSet.Fitness_Class);
            // TODO: This line of code loads data into the 'memberFitnessDataSet.Class_Booking' table. You can move, or remove it, as needed.
            this.class_BookingTableAdapter.Fill(this.memberFitnessDataSet.Class_Booking);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            T1 = memberFitnessDataSet.Member.FindByMember_ID(Int32.Parse(textBox1.Text));
            T2 = memberFitnessDataSet.Membership.FindByMembershipID(T1.Membership_type_ID);

            Member_ID = T1.Member_ID;
            First_Name = T1.First_Name;
            Last_Name = T1.Last_Name;
            Address = T1.Address;
            Phone_Number = T1.Phone_Number;
            Payment_Frequency = T1.Payment_Frequency;
            Discount_Amount = T1.Discount_Amount;
            Extra_Amount = T1.Extra_Amount;
            Total_Amount = T1.Total_Amount;
            Membership_Type_ID = T1.Membership_type_ID;
            membershipType = T2.Description;
            Duration = T1.Duration;



            // inputs all the information that the user has searched for into the text box - member details.
            string output1 = "Member ID: " + Member_ID + Environment.NewLine +
                "First Name: " + First_Name + Environment.NewLine +
                "Last Name: " + Last_Name + Environment.NewLine +
                "Address: " + Address + Environment.NewLine +
                "Phone Number: " + Phone_Number + Environment.NewLine +
                "Payment Frequency " + Payment_Frequency + Environment.NewLine +
                "Duration: " + Duration + Environment.NewLine +
                "Extra amount: $" + Extra_Amount + Environment.NewLine +
                "Discount amount: $" + Discount_Amount + Environment.NewLine +
                "Total amount: $" + Total_Amount + Environment.NewLine +
                "membership Type: " + membershipType;

            string temp = "";
            DataRow targetRow = null;



            foreach (DataRow r in memberFitnessDataSet.Class_Booking.Rows)
            {
                if (T1.Member_ID == Int32.Parse(r["Member ID"].ToString()))
                {
                    //a) store the row
                    targetRow = r;

                    //b) extract class information
                    T3 = memberFitnessDataSet.Fitness_Class.FindByFitness_Class_ID(Int32.Parse(r["Fitness Class ID"].ToString()));

                    //c) concatitate result
                    temp = temp + "Class: " + T3.Description + Environment.NewLine + 
                        "Trainer: " + T3.Instructor_Name + Environment.NewLine +
                        "Slot: " + r["Slot"].ToString() + Environment.NewLine + Environment.NewLine;
                }
            }
            if (targetRow == null)
            {
                temp = "No Booking.";
            }

            //4) Update details
            Member_ID = T1.Member_ID;
            First_Name = T1.First_Name;
            Last_Name = T1.Last_Name;
            Address = T1.Address;
            Phone_Number = T1.Phone_Number;
            Payment_Frequency = T1.Payment_Frequency;
            Discount_Amount = T1.Discount_Amount;
            Extra_Amount = T1.Extra_Amount;
            Membership_Type_ID = T1.Membership_type_ID;
            Duration = T1.Duration;
            baseBookingDetails = temp;


            //display results
            textBox2.Text = output1;
            textBox3.Text = baseBookingDetails;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //data view for the tables to display the grid for
            DataView memberDataView = new DataView(memberFitnessDataSet.Tables["Member"]);
            string queryDV;

            //query changes upon selection
            if (radioButton1.Checked)
            {
                queryDV = "[First Name] = '" + textBox4.Text + "'";
            }
            else if (radioButton2.Checked)
            {
                queryDV = "[Membership type ID] = " + textBox5.Text;

            }
            else
            {
                queryDV = "[First Name] = '" + textBox4.Text + "'" + "AND " + "[Membership type ID] = " + textBox5.Text;
            }

            memberDataView.RowFilter = queryDV;
            memberDataGridView.DataSource = memberDataView;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            memberDataGridView.DataSource = new DataView(memberFitnessDataSet.Tables["member"]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClassBookingForm a = new ClassBookingForm();
            a.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HelpForm a = new HelpForm();
            a.Show();
            this.Hide();
        }
    }
}
