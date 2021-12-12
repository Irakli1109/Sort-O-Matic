using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Sort_O_Matic
{
    /*
     * Irakli Turabelidze
     * RedId: 824657178
     * Date: 12 December, 2021
     */
    public partial class Form1 : Form 
    {
        double[] myArray ;
        Label [] labels = new Label [15];
        //random onject for creating random numbers
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //i have simply grouped all important labels in the array
            //in order to have easier access in the for loop
            labels[1] = label1;
            labels[2] = label2;
            labels[3] = label3;
            labels[4] = label4;
            labels[5] = label5;
            labels[6] = label6;
            labels[7] = label7;
            labels[8] = label8;
            labels[9] = label9;
            labels[10] = label10;
            labels[11] = label11;
            labels[12] = label12;
            labels[13] = label13;
            labels[14] = label14;
            toolStripMenuItem1.Enabled = false;
        }

        

        async void insertion_sort_ascending ( double[ ] A) 
        {
            int n = A.Length;
            toolStripMenuItem1.Enabled = false;
            Generate_Array.Enabled = false;
            display(A); //display initial array
            await Task.Delay(1000);
            
            for ( int i = 0 ;i < n ; i++ ) {
            /*storing current element whose left side is checked for its 
                     correct position .*/

             double temp = A[ i ];    
             int j = i;

                  while(  j > 0  && temp < A[ j -1]) { 

                   // moving the left side element to one position forward.
                        A[ j ] = A[ j-1];
                    //color elements that must be exchanged
                    labels[j].BackColor = Color.Red;
                    labels[j+1].BackColor = Color.Yellow;
                    await Task.Delay(1000); //wait for coloring
                    //exchange elements and colors
                    labels[j+1].BackColor = Color.Red;
                    labels[j].BackColor = Color.Yellow;
                    string change = labels[j + 1].Text; //store string value of labels[j+1]
                    //interchange values
                    labels[j+1].Text = labels[j].Text;
                    labels[j].Text = change;
                    
                    await Task.Delay(1000);
                    //return default green background
                    labels[j].BackColor = Color.LimeGreen;
                    labels[j + 1].BackColor = Color.LimeGreen;
                    await Task.Delay(1000);
                    j = j - 1;

                   }
                // moving current element to its  correct position.
                
                await Task.Delay(1000);
                A[ j ] = temp;  
                labels[j+1].Text = (temp).ToString();
                
                await Task.Delay(1000);
            }
            //enabling buttons again
            Generate_Array.Enabled = true;
            toolStripMenuItem1.Enabled = true;
        }

        async void insertion_sort_descending(double[] A)
        {
            //disable buttons
            toolStripMenuItem1.Enabled = false;
            Generate_Array.Enabled = false;
            int n = A.Length;

            display(A);
            await Task.Delay(1000);
            
            for (int i = 0; i < n; i++)
            {
                //repeating the same process as up

                double temp = A[i];
                int j = i;

                while (j > 0 && temp > A[j - 1])
                { //sign change make descending

                    // moving the left side element to one position forward.
                    A[j] = A[j - 1];
                    //color elements that must be exchanged
                    labels[j].BackColor = Color.Red;
                    labels[j + 1].BackColor = Color.Yellow;
                    await Task.Delay(1000); //wait for coloring
                    //exchange element s and colors
                    labels[j + 1].BackColor = Color.Red;
                    labels[j].BackColor = Color.Yellow;
                    string change = labels[j + 1].Text; //store labels[j+1] value
                    //interchange values
                    labels[j + 1].Text = labels[j].Text;
                    labels[j].Text = change;

                    await Task.Delay(1000);
                    //set default colors
                    labels[j].BackColor = Color.LimeGreen;
                    labels[j + 1].BackColor = Color.LimeGreen;
                    await Task.Delay(1000);
                    j = j - 1;

                }
                // moving current element to its  correct position.
                await Task.Delay(1000);
                A[j] = temp;
                labels[j + 1].Text = (temp).ToString();
                
                await Task.Delay(1000);
            }
            //enable buttons for use
            toolStripMenuItem1.Enabled = true;
            Generate_Array.Enabled = true;
        }


        async void shell_sort_ascending(double [] arr) //double array parameter
        {
            int n = arr.Length;
            //disable buttons
            toolStripMenuItem1.Enabled = false;
            Generate_Array.Enabled = false;
            display(arr);
            await Task.Delay(1000);

            // Start with a big gap,
            // then reduce the gap
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size.
                // The first gap elements a[0..gap-1] are already
                // in gapped order keep adding one more element
                // until the entire array is gap sorted
                for (int i = gap; i < n; i += 1)
                {
                    // save a[i] in temp variable
                    double temp = arr[i];

                    // shift earlier gap-sorted elements up until
                    // the correct location for a[i] is found
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                        //colors indicate that values should swap
                        labels[j + 1].BackColor = Color.Red;
                        labels[j + 1- gap].BackColor = Color.Yellow;
                        await Task.Delay(1000); //wait 1 second
                        //swapping and changing colors
                        labels[j + 1].Text = labels[j - gap + 1].Text;
                        labels[j + 1 - gap].Text = (temp).ToString();
                        labels[j + 1].BackColor = Color.Yellow;
                        labels[j + 1 - gap].BackColor = Color.Red;
                        await Task.Delay(1000); //wait again 1 second
                        //set default colors
                        labels[j + 1].BackColor = Color.LimeGreen;
                        labels[j + 1 - gap].BackColor = Color.LimeGreen;
                        await Task.Delay(1000); 
                    }
                    // put temp (the original a[i])
                    // in its correct location
                    arr[j] = temp;
                    
                }
            }
            //enable buttons
            toolStripMenuItem1.Enabled = true;
            Generate_Array.Enabled = true;
        }

        async void shell_sort_descending(double[] arr)
        {
            int n = arr.Length;
            //disable buttons
            toolStripMenuItem1.Enabled = false;
            Generate_Array.Enabled = false;

            display(arr); //display array
            await Task.Delay(1000);

            // Start with a big gap,
            // then reduce the gap
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                
                for (int i = gap; i < n; i += 1)
                {
                    // save a[i] in temp and
                    // make a hole at position i
                    double temp = arr[i];

                    // shift earlier gap-sorted elements up until
                    // the correct location for a[i] is found
                    int j;
                    for (j = i; j >= gap && arr[j - gap] < temp; j -= gap) //i have changed sign for descending
                    {
                        arr[j] = arr[j - gap];
                        //make proper labels ready for swapping
                        labels[j + 1].BackColor = Color.Red;
                        labels[j + 1 - gap].BackColor = Color.Yellow;
                        await Task.Delay(1000); //wait 1 second before swapping
                        //swapping values of labels and colors
                        labels[j + 1].Text = labels[j - gap + 1].Text;
                        labels[j + 1 - gap].Text = (temp).ToString();
                        labels[j + 1].BackColor = Color.Yellow;
                        labels[j + 1 - gap].BackColor = Color.Red;
                        await Task.Delay(1000); //Wait 1 second
                        //setting default colors
                        labels[j + 1].BackColor = Color.LimeGreen;
                        labels[j + 1 - gap].BackColor = Color.LimeGreen;
                        await Task.Delay(1000);
                    }
                    // put temp (the original a[i])
                    // in its correct location
                    arr[j] = temp;
                    //labels[j + 1].BackColor = Color.Yellow;

                }
            }
            //enable buttons
            toolStripMenuItem1.Enabled = true;
            Generate_Array.Enabled = true;
        }
        

        async void heapSort_ascending(double[] arr, int n)
        {

            display(arr);
            //disable buttons
            toolStripMenuItem1.Enabled = false;
            Generate_Array.Enabled = false;
            await Task.Delay(1000); //wait 1 second
            //this loop is for building max heap
            for (int i = 1; i < n; i++)
            {
                // if child is bigger than parent
                if (arr[i] > arr[(i - 1) / 2])
                {
                    int j = i;

                    // swapping
                    while (arr[j] > arr[(j - 1) / 2])
                    {
                        var change3 = labels[j + 1].Text; //store lables[j+1] text in change3
                        //set colors for swapping
                        labels[j + 1].BackColor = Color.Red;
                        labels[(j - 1) / 2 + 1].BackColor = Color.Yellow;
                        await Task.Delay(1000); //wait 1 second
                        //interchange values and colors of labels
                        labels[j + 1].Text = labels[(j - 1) / 2 + 1].Text;
                        labels[(j - 1) / 2 + 1].Text = change3;
                        labels[(j - 1) / 2 + 1].BackColor = Color.Red;
                        labels[j + 1].BackColor = Color.Yellow;
                        SwapDoubles(ref arr[j], ref arr[(j - 1) / 2]); //swap values in aray
                        await Task.Delay(1000); //wait 1 second
                        //set default colors
                        labels[(j - 1) / 2 + 1].BackColor = Color.LimeGreen;
                        labels[j + 1].BackColor = Color.LimeGreen;
                        await Task.Delay(1000);

                        j = (j - 1) / 2;
                    }
                }
            }
            //after building maxheap
            for (int i = n - 1; i > 0; i--)
            {

                // swap value of first indexed
                // with last indexed
                var change1 = labels[1].Text;
                labels[1].BackColor = Color.Red;
                labels[i+1].BackColor = Color.Yellow;
                await Task.Delay(1000);
                labels[1].Text = labels[i + 1].Text;
                labels[i + 1].Text = change1;
                labels[i+1].BackColor = Color.Red;
                labels[1].BackColor = Color.Yellow;
                SwapDoubles(ref arr[0], ref arr[i]);
                await Task.Delay(1000);
                labels[i + 1].BackColor = Color.LimeGreen;
                labels[1].BackColor = Color.LimeGreen;
                await Task.Delay(1000);
                // maintaining heap property
                // after each swapping
                int j = 0, index;

                do
                {
                    index = (2 * j + 1);

                    // if left child is smaller than
                    // right child point index variable
                    // to right child
                    if (index < (i - 1) && arr[index] < arr[index + 1])
                        index++;

                    
                    if (index < i && arr[j] < arr[index])
                    {
                        var change2 = labels[j+1].Text;
                        //setting colors
                        labels[j+1].BackColor = Color.Red;
                        labels[index + 1].BackColor = Color.Yellow;
                        await Task.Delay(1000);
                        //changing values and colors
                        labels[j+1].Text = labels[index + 1].Text;
                        labels[index + 1].Text = change2;
                        labels[index + 1].BackColor = Color.Red;
                        labels[j+1].BackColor = Color.Yellow;
                        //change array values as well with custom swap
                        SwapDoubles(ref arr[j], ref arr[index]);
                        await Task.Delay(2000);
                        labels[index + 1].BackColor = Color.LimeGreen;
                        labels[j+1].BackColor = Color.LimeGreen;
                        await Task.Delay(1000);
                    }
                    j = index;

                } while (index < i);
            }
            //enable buttons
            toolStripMenuItem1.Enabled = true;
            Generate_Array.Enabled = true;
        }

        async void heapSort_descending(double[] arr, int n)
        {

            display(arr);
            toolStripMenuItem1.Enabled = false;
            Generate_Array.Enabled = false;
            await Task.Delay(1000);
            //building max heap
            for (int i = 1; i < n; i++)
            {
                // if child is bigger than parent
                if (arr[i] < arr[(i - 1) / 2])
                {
                    int j = i;

                    // swap child and parent until
                    // parent is smaller
                    while (arr[j] < arr[(j - 1) / 2])
                    {
                        var change3 = labels[j + 1].Text;
                        labels[j + 1].BackColor = Color.Red;
                        labels[(j - 1) / 2 + 1].BackColor = Color.Yellow;
                        await Task.Delay(1000);
                        labels[j + 1].Text = labels[(j - 1) / 2 + 1].Text;
                        labels[(j - 1) / 2 + 1].Text = change3;
                        labels[(j - 1) / 2 + 1].BackColor = Color.Red;
                        labels[j + 1].BackColor = Color.Yellow;
                        SwapDoubles(ref arr[j], ref arr[(j - 1) / 2]);
                        await Task.Delay(1000);
                        labels[(j - 1) / 2 + 1].BackColor = Color.LimeGreen;
                        labels[j + 1].BackColor = Color.LimeGreen;
                        await Task.Delay(1000);

                        j = (j - 1) / 2;
                    }
                }
            }

            for (int i = n - 1; i > 0; i--)
            {

                // swap value of first indexed
                // with last indexed
                var change1 = labels[1].Text;
                //set colors
                labels[1].BackColor = Color.Red;
                labels[i + 1].BackColor = Color.Yellow;
                await Task.Delay(1000);
                //swapp
                labels[1].Text = labels[i + 1].Text;
                labels[i + 1].Text = change1;
                labels[i + 1].BackColor = Color.Red;
                labels[1].BackColor = Color.Yellow;
                SwapDoubles(ref arr[0], ref arr[i]);
                await Task.Delay(1000);
                //set defaults
                labels[i + 1].BackColor = Color.LimeGreen;
                labels[1].BackColor = Color.LimeGreen;
                await Task.Delay(1000);
                // maintaining heap property
                // after each swapping
                int j = 0, index;

                do
                {
                    index = (2 * j + 1);

                    // if left child is smaller than
                    // right child point index variable
                    // to right child
                    if (index < (i - 1) && arr[index] > arr[index + 1])
                        index++;

                    // if parent is smaller than child
                    // then swapping parent with child
                    // having higher value
                    if (index < i && arr[j] > arr[index])
                    {
                        var change2 = labels[j + 1].Text;
                        //set colors
                        labels[j + 1].BackColor = Color.Red;
                        labels[index + 1].BackColor = Color.Yellow;
                        await Task.Delay(1000);
                        //changing values
                        labels[j + 1].Text = labels[index + 1].Text;
                        labels[index + 1].Text = change2;
                        labels[index + 1].BackColor = Color.Red;
                        labels[j + 1].BackColor = Color.Yellow;
                        //swapping
                        SwapDoubles(ref arr[j], ref arr[index]);
                        await Task.Delay(1000);
                        //setting defaults
                        labels[index + 1].BackColor = Color.LimeGreen;
                        labels[j + 1].BackColor = Color.LimeGreen;
                        await Task.Delay(1000);
                    }
                    j = index;

                } while (index < i);
            }
            //enable buttons
            toolStripMenuItem1.Enabled = true;
            Generate_Array.Enabled = true;
        }

        async void bubbleSort_ascending(double[] arr)
        {
            
            int n = arr.Length;
            //disabling buttons
            toolStripMenuItem1.Enabled = false;
            Generate_Array.Enabled = false;
            //display initial array
            display(arr);
            await Task.Delay(1000);

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        //setcolors for swapping
                        labels[j + 1].BackColor = Color.Yellow;
                        labels[j + 2].BackColor = Color.Red;
                        await Task.Delay(1000);
                        //swap vaues
                        SwapDoubles(ref arr[j], ref arr[j + 1]);
                        //swapping
                        var change = labels[j + 1].Text;
                        labels[j + 1].Text = labels[j + 2].Text;
                        labels[j + 2].Text = change;
                        labels[j + 1].BackColor = Color.Red;
                        labels[j + 2].BackColor = Color.Yellow;
                        await Task.Delay(1000);
                        //default positions
                        labels[j + 1].BackColor = Color.LimeGreen;
                        labels[j + 2].BackColor = Color.LimeGreen;
                        await Task.Delay(1000);
                    }
            //enable buttons
            toolStripMenuItem1.Enabled = true;
            Generate_Array.Enabled = true;
        }

        async void bubbleSort_descending(double[] arr)
        {

            int n = arr.Length;
            //disable buttons3
            toolStripMenuItem1.Enabled = false;
            Generate_Array.Enabled = false;
            display(arr);
            await Task.Delay(1000);

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] < arr[j + 1])
                    {//set colors for swapping
                        labels[j + 1].BackColor = Color.Yellow;
                        labels[j + 2].BackColor = Color.Red;
                        await Task.Delay(1000);
                        //swap
                        SwapDoubles(ref arr[j], ref arr[j + 1]);
                        var change = labels[j + 1].Text;
                        labels[j + 1].Text = labels[j + 2].Text;
                        labels[j + 2].Text = change;
                        //change colors and label texts
                        labels[j + 1].BackColor = Color.Red;
                        labels[j + 2].BackColor = Color.Yellow;
                        await Task.Delay(1000);
                        //set default colors
                        labels[j + 1].BackColor = Color.LimeGreen;
                        labels[j + 2].BackColor = Color.LimeGreen;
                        await Task.Delay(1000);
                    }
            //enable buttons
            toolStripMenuItem1.Enabled = true;
            Generate_Array.Enabled = true;
        }

        //custom displa method
        void display(double[] A)
        {
            for (int i = 1; i <= A.Length; i++)
            {
                //labels get array values as a text
                labels[i].Text = myArray[i - 1].ToString();
            }
        }
        //custom swap
        void SwapDoubles(ref double val1, ref double val2) //gets paramters with reference
        {
            //swaps values via using temp variable
            var temp = val1;
            val1 = val2;
            val2 = temp;
        }

        private void ascendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //button for insertion sort ascending
            insertion_sort_ascending(myArray);
            
        }

        private void descendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //button for descending insertion sort
            insertion_sort_descending(myArray);
        }

        private void ascendingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //button for ascending shell sort
            shell_sort_ascending(myArray);
        }

        private void descendingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //button for descending shell sort
            shell_sort_descending(myArray);
        }

        private void ascendingToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //button for ascending heap sort
            heapSort_ascending(myArray, myArray.Length);
        }

        private void descendingToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //button for descending heap sort
            heapSort_descending(myArray, myArray.Length);
        }

        private void ascendingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //button for ascending 
            bubbleSort_ascending(myArray);
        }

        private void descendingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //button for bubble sort descending
            bubbleSort_descending(myArray);
        }
        //button of generate array
        private void Generate_Array_Click(object sender, EventArgs e)
        { //try catch block for catching possible errors
            try
            {
                int num = int.Parse(textBox1.Text); //parse input string
                if (num < 1 || num > 7)
                    throw new Exception("Enter Number from 1 to 7"); //error if value is not in range
                myArray = new double[num];
                for(int i=0; i<num; i++) //populate array with randoms
                {
                    myArray[i] = random.Next(1, 100); 
                    labels[i+8].Text = myArray[i].ToString();
                }
                for(int i=num+7; i<14; i++) //fill empties with 0
                {
                    labels[i + 1].Text = "0";
                }
                //enable menu button
                toolStripMenuItem1.Enabled = true;


            }
            catch (Exception ex)
            {
                //showing error message
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
