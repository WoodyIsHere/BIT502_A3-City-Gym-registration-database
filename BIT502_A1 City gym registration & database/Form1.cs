using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace assignment_1_prototype___sean
{
    public partial class Form1 : Form
    {


        //=======Class atributes ===============
        int member_ID;
        string first_Name;
        string last_Name;
        string address;
        int phonenumber;
        string payment_type;
        float discount_amount;
        float extra_amount;
        float total_amount;
        int Membership_type_ID;
        string baseDuration;
        int baseCost;
        string baseMembershiptype;

        int[] membershipID = { 0, 0, 0 };
        int[] membershipCost = { 0, 0, 0 };
        string[] membershipType = { "", "", "" };
        string[] duration = { "", "" }; 
        //=========================================


        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'memberFitnessDataSet.Class_Booking' table. You can move, or remove it, as needed.
            this.class_BookingTableAdapter.Fill(this.memberFitnessDataSet.Class_Booking);
            // TODO: This line of code loads data into the 'memberFitnessDataSet.Fitness_Class' table. You can move, or remove it, as needed.
            this.fitness_ClassTableAdapter.Fill(this.memberFitnessDataSet.Fitness_Class);
            // TODO: This line of code loads data into the 'memberFitnessDataSet.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.memberFitnessDataSet.Member);
            // TODO: This line of code loads data into the 'memberFitnessDataSet.Membership' table. You can move, or remove it, as needed.
            this.membershipTableAdapter.Fill(this.memberFitnessDataSet.Membership);

            // retriving the forms and executing the membership retrival method.
            membershipRetrivalMethod();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Step 1: error checking
            bool dec1 = errorControlMethod();

            //step 2: calculation
            if (dec1)
            {
                MessageBox.Show("error please make sure all fields are filled out.");
            }

            else
            {
                // do caclculation
                double baseMembershipCost; // this calculates the price of membership depending on if the user selects basic, regular, preimum.
                if (radioButton1.Checked)
                {
                    baseMembershipCost = 10;
                }
                else if (radioButton2.Checked)
                {
                    baseMembershipCost = 15;
                }
                else 
                {
                    baseMembershipCost = 20;
                }
                
                double discount1; // this calculates the discount the user based on how long the membership is
                if (radioButton4.Checked)
                {
                    discount1 = 0;
                }

                else if (radioButton5.Checked)
                {
                    discount1 = 2;
                }

                else 
                {
                    discount1 = 5;
                }

                double discount2; // this calculates the % discount depending on the payment type
                if (radioButton7.Checked)
                {
                    discount2 = 0.01;
                }
                else
                {
                    discount2 = 0;
                }
                double paymentFreq1; // this is if the user selects to pay either weekly or monthly
                if (radioButton9.Checked)
                {
                    paymentFreq1 = 1;
                }
                else
                {
                    paymentFreq1 = 4;
                }
                double extraCosts1; // this is if the user selects any of the extras.
                if (checkBox1.Checked)
                {
                    extraCosts1 = 1;
                }
                else
                {
                    extraCosts1 = 0;
                }
                double extraCosts2;
                if (checkBox2.Checked)
                {
                    extraCosts2 = 20;
                }
                else
                {
                    extraCosts2 = 0;
                }
                double extraCosts3;
                if (checkBox3.Checked)
                {
                    extraCosts3 = 20;
                }
                else
                {
                    extraCosts3 = 0;
                }
                double extraCosts4;
                if (checkBox4.Checked)
                {
                    extraCosts4 = 2;
                }
                else
                {
                    extraCosts4 = 0;
                }
                double extraCosts = extraCosts1 + extraCosts2 + extraCosts3 + extraCosts4; // caclulates total amount of extras/add ons.


                double totalDiscount;
                totalDiscount = discount1 + (baseMembershipCost * discount2); // calculates total discount from the users selections.
                double netMembershipCost = baseMembershipCost + extraCosts - totalDiscount; // calculates net membership cost.
                double regularPayment;
                regularPayment = netMembershipCost * paymentFreq1; // calculates total membership cost (including monthly & weekly payment.
                textBox10.Text = regularPayment.ToString();
                textBox9.Text = netMembershipCost.ToString();
                textBox11.Text = extraCosts.ToString();
                textBox12.Text = totalDiscount.ToString();
            }
            membershipRadioMethod();
            membershipPaymentFreqMethod();

        }
        
        private bool errorControlMethod() 
            // checks to see if that the user has actually inputted text and selected membership options.
        {
            bool a1 = false;
            bool a2 = true;
            bool a3 = true;
            bool a4 = true;
            bool a5 = true;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox5.TextLength == 0 || textBox6.TextLength == 0 || textBox7.TextLength == 0 || textBox8.TextLength == 0)
            { // checks to see that the user has entered text into all text boxes.
                a1 = true;
            }
               
                
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            { // checks to see that the user has selected a type of membership.
                a2 = false;
            }

            if (radioButton4.Checked || radioButton5.Checked || radioButton6.Checked)
            { // checks to see that the user has selected a membership duration.
                a3 = false;
            }

            if (radioButton7.Checked || radioButton8.Checked)
            { //checks to see that the user has chosen a payment option.
                a4 = false;
            }

            if (radioButton9.Checked || radioButton10.Checked)
            { // checks to see if the user has selected a payment schedule.
                a5 = false;
            }

            return (a1 || a2 || a3 || a4 || a5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool dec2 = errorControlMethod2();
            // checks to see if the user has calculated membership and has input text/ selected membership options
            if (dec2)
            {
                MessageBox.Show("error please make sure you click the calculate button.");
            }

            else
            {
                try
                {

                    TextWriter wr = new StreamWriter("C:/Temp/GymMembershipForm.txt",true);
                    // creates a new text file in the "Temp" folder. Any new submissions will be added to the text file.

                    string contactDetails = "First Name:" + textBox1.Text +
                        "\r\n" + "Last Name: " + textBox2.Text +
                        "\r\n" + "Phone Number: " + textBox8.Text +
                        "\r\n" + "Home Address: " + textBox3.Text +
                        "\r\n" + "Suburb: " + textBox5.Text +
                        "\r\n" + "City: " + textBox6.Text +
                        "\r\n" + "Postcode: " + textBox7.Text;
                    // string colates all of the personal details into one string.

                    string membershipUserCosts = "Membership Cost Total: " + textBox9.Text +
                        "\r\n" + "Regular Payment Amount: " + textBox10.Text +
                        "\r\n" + "Total of extra charges: " + textBox11.Text +
                        "\r\n" + "Total Discount: " + textBox12.Text;
                    // colates all membership payment calculations into one string

                    wr.WriteLine(contactDetails);
                    wr.WriteLine(); // creates a blank line on text document for ease of reading.


                    if (radioButton1.Checked)
                    {
                        wr.WriteLine("Membership: Basic");
                    }

                    else if (radioButton2.Checked)
                    {
                        wr.WriteLine("Membership: Regular");
                    }

                    else
                    {
                        wr.WriteLine("Membership: Premium");
                    }
                    // displays the membership option the user selected in the text file
                    wr.WriteLine();
                    if (radioButton4.Checked)
                    {
                        wr.WriteLine("Membership Length: 3 Months");
                    }
                    else if (radioButton5.Checked)
                    {
                        wr.WriteLine("Membership Length: 12 Months");
                    }
                    else
                    {
                        wr.WriteLine("Membership Length: 24 Months");
                    }
                    // displays the membership length option the user selected in the text file
                    wr.WriteLine();
                    if (radioButton7.Checked)
                    {
                        wr.WriteLine("Direct Debit: Yes");
                    }
                    else
                    {
                        wr.WriteLine("Direct Debit: No");
                    }
                    // displays the direct debit option the user selected in the text file
                    wr.WriteLine();
                    if (radioButton9.Checked)
                    {
                        wr.WriteLine("Payment Frequency: Weekly");
                    }
                    else
                    {
                        wr.WriteLine("Payment Frequency: Monthly");
                    }
                    // displays the payment frequency option the user selected in the text file
                    wr.WriteLine();
                    wr.WriteLine("Extra Costs: ");
                    if (checkBox1.Checked)
                    {
                        wr.WriteLine("24/7 Access");
                    }
                    if (checkBox2.Checked)
                    {
                        wr.WriteLine("Personal Trainer");
                    }
                    if (checkBox3.Checked)
                    {
                        wr.WriteLine("Diet Consultation");
                    }
                    if (checkBox4.Checked)
                    {
                        wr.WriteLine("Access Online Fitness Videos");
                    }

                    // displays the extra options the user selected in the text file
                    wr.WriteLine();
                    wr.WriteLine(membershipUserCosts);
                    wr.WriteLine();
                    wr.Close();
                    MessageBox.Show("Membership form saved to C:/Temp/ as GymMembershipForm.txt");
                    // displays a pop-up message of which directory the text file has been saved to.
                }

                catch
                {
                    MessageBox.Show("File reading error. trying to save membership form to C:/Temp/. Please make sure C:/Temp/ is accessible");
                    //if the user has not created the temp folder/temp folder is in the wrong drive/ temp folder is locked this message will appear.
                }
            }

        }
        private bool errorControlMethod2()
        // checks to see if that the user has actually inputted text, selected membership options and calculated costs.
        {
            bool b1 = false;
            bool b2 = true;
            bool b3 = true;
            bool b4 = true;
            bool b5 = true;
            bool b6 = false;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox5.TextLength == 0 || textBox6.TextLength == 0 || textBox7.TextLength == 0 || textBox8.TextLength == 0)
            { // checks to see that the user has entered text into all text boxes.
                b1 = true;
            }


            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            { // checks to see that the user has selected a type of membership.
                b2 = false;
            }

            if (radioButton4.Checked || radioButton5.Checked || radioButton6.Checked)
            { // checks to see that the user has selected a membership duration.
                b3 = false;
            }

            if (radioButton7.Checked || radioButton8.Checked)
            { //checks to see that the user has chosen a payment option.
                b4 = false;
            }

            if (radioButton9.Checked || radioButton10.Checked)
            { // checks to see if the user has selected a payment schedule.
                b5 = false;
            }
            if (textBox9.TextLength == 0)
            { /* checks to see if the user has calculated membership costs. only membership cost total 
               * is checked as the user has options to not choose total discount, extra charges, etc. */
                b6 = true;
            }

            return (b1 || b2 || b3 || b4 || b5 || b6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu b = new MainMenu();
            b.Show();
            this.Hide();
        }

        private void membershipBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.membershipBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.memberFitnessDataSet);

        }

        private void membershipRetrivalMethod()
        {
            //Retrives the membership table and assigns values based on global attributes.
            int i = 0;
            foreach (DataRow r in memberFitnessDataSet.Membership.Rows)
            {
                membershipID[i] = Int32.Parse(r["MembershipID"].ToString());
                membershipCost[i] = Int32.Parse(r["Cost"].ToString());
                membershipType[i] = r["Description"].ToString();
                i++;
            }
        }
        private void membershipRadioMethod()
        {
            int index;
            if (radioButton1.Checked)
            {
                index = 0;
            }
            else if (radioButton2.Checked)
            {
                index = 1;
            }
            else
            {
                index = 2;
            }
            Membership_type_ID = membershipID[index];
            baseCost = membershipCost[index];
            baseMembershiptype = membershipType[index];
        }
        private void membershipPaymentFreqMethod()
        {
            int index2;
            if (radioButton9.Checked)
            {
                index2 = 0;
            }
            else
            {
                index2 = 1;
            }
            baseDuration = duration[index2];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //error control method.
            bool dec3 = errorControlMethod2(); 
            if (dec3)
            {
                //shows a message to ensure all fields are filled.
                MessageBox.Show("error please make sure you click the calculate button.");
            }

            else
            {
                //Retrieves the data that the user inputs and inputs it into the table
                MemberFitnessDataSet.MemberRow newRow = memberFitnessDataSet.Member.NewMemberRow();
                newRow.Member_ID = memberFitnessDataSet.Member.Count + 1;
                newRow.First_Name = textBox1.Text;
                newRow.Last_Name = textBox2.Text;
                newRow.Address = textBox3.Text + " " + textBox5.Text;
                newRow.Phone_Number = Int32.Parse(textBox8.Text);
                if (radioButton9.Checked)
                {
                   newRow.Payment_Frequency =  "weekly";
                }
                else
                {
                    newRow.Payment_Frequency = "monthly";
                }
                newRow.Discount_Amount = float.Parse(textBox12.Text);
                newRow.Extra_Amount = float.Parse(textBox11.Text);
                newRow.Total_Amount = float.Parse(textBox9.Text);
                newRow.Membership_type_ID = Membership_type_ID;
                if (radioButton4.Checked)
                {
                    newRow.Duration = "3 Months";
                }
                else if (radioButton5.Checked)
                {
                    newRow.Duration = "12 Months";
                }
                else
                {
                    newRow.Duration = "24 Months";
                }

                memberFitnessDataSet.Member.Rows.Add(newRow);
                memberTableAdapter.Update(memberFitnessDataSet.Member);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchForm a = new SearchForm();
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
