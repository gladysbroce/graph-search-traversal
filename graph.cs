/*
 * Program Description: This program performs the following operations on predefined graphs:
 * [1] Perform Depth First Traversal
 * [2] Perform Breadth First Traversal
 * [3] Search Graph 1(DFS)
 * [4] Search Graph 2(BFS)
 * [5] Exit
 */

using System;
using System.Windows.Forms;
using System.Drawing;

namespace Graph {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();

            // Set form title
            this.Text = "Graphs";

            // Hide forms during initial load
            HideForms();
        }

        /**
         * Method for [1] Perform Depth First Traversal button
         */
        private void BtnDFT_Click(object sender, EventArgs e) {
            labelTitle.Text = btnDFT.Text;
            labelValue.Text = "Graph #";
            ShowRadioForm();
        }

        /**
         * Method for [2] Perform Breadth First Traversal button
         */
        private void BtnBFT_Click(object sender, EventArgs e) {
            labelTitle.Text = btnBFT.Text;
            labelValue.Text = "Graph #";
            ShowRadioForm();
        }
        
        /**
         * Method for [3] Search Graph 1 (DFS) button
         */
        private void BtnDFS_Click(object sender, EventArgs e) {
            labelTitle.Text = btnDFS.Text;
            labelValue.Text = "Vertex";
            ShowSearchForm();
        }

        /**
         * Method for [4] Search Graph 2 (BFS) button
         */
        private void BtnBFS_Click(object sender, EventArgs e) {
            labelTitle.Text = btnBFS.Text;
            labelValue.Text = "Vertex";
            ShowSearchForm();
        }

        /**
         * Method for [5] Exit button
         */
        private void BtnExit_Click(object sender, EventArgs e) {
            Close();
        }

        /**
         * Shows form used for traversal
         */
        private void ShowRadioForm() {
            // Hide elements
            labelMsg.Hide();
            txtValue.Hide();

            // Show elements
            labelValue.Visible = true;
            radioBtn1.Visible = true;
            radioBtn2.Visible = true;
            btnExecute.Visible = true;

            // Set graph 1 as default
            radioBtn1.Checked = true;

            // Enable Execute button
            btnExecute.Enabled = true;
        }

        /**
         * Shows form used for search
         */
        private void ShowSearchForm() {
            // Hide elements
            labelMsg.Hide();
            radioBtn1.Hide();
            radioBtn2.Hide();

            // Show form elements
            labelValue.Visible = true;
            txtValue.Visible = true;
            btnExecute.Visible = true;

            // Disable Execute button
            btnExecute.Enabled = false;
        }

        /**
         * Hides form elements
         */
        private void HideForms() {
            // Clear message
            labelMsg.Text = String.Empty;

            // Clear value
            txtValue.Text = String.Empty;

            // Disable Execute button
            btnExecute.Enabled = false;

            // Hide form elements
            labelMsg.Hide();
            labelValue.Hide();
            txtValue.Hide();
            radioBtn1.Hide();
            radioBtn2.Hide();
            btnExecute.Hide();
        }

        /**
         * Method for execute("Go") button
         */
        private void BtnExecute_Click(object sender, EventArgs e) {

            // Determine the operation to be performed
            switch (labelTitle.Text) {
                case "Perform Depth First Traversal":
                    DFTraversal();
                    break;

                case "Perform Breadth First Traversal":
                    BFTraversal();
                    break;

                case "Search Graph 1 (DFS)":
                    DFSearch();
                    break;

                case "Search Graph 2 (BFS)":
                    BFSearch();
                    break;
            }
        }

        /**
         * Enables execute button when input is entered
         */
        private void TxtValue_TextChanged(object sender, EventArgs e) {
            btnExecute.Enabled = !string.IsNullOrWhiteSpace(txtValue.Text);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        /**
         * Depth First Traversal
         */
        private void DFTraversal() {

            // Traverse Graph 1: 1367452
            if (radioBtn1.Checked == true) {
                Graph1 g1 = new Graph1();
                g1.DFT(0);
                DisplayMsg("Success", "Output: " + g1.VisitOrder);
            }
            // Traverse Graph 2: ABEDC
            else {
                Graph2 g2 = new Graph2();
                g2.DFT(0);
                DisplayMsg("Success", "Output: " + g2.VisitOrder);
            }
        }

        /**
         * Breadth First Traversal
         */
        private void BFTraversal() {

            // Traverse Graph 1: 1234657
            if (radioBtn1.Checked == true) {
                Graph1 g1 = new Graph1();
                g1.BFT(0);
                DisplayMsg("Success", "Output: " + g1.VisitOrder);
            }
            // Traverse Graph 2: ABECD
            else {
                Graph2 g2 = new Graph2();
                g2.BFT(0);
                DisplayMsg("Success", "Output: " + g2.VisitOrder);
            }
        }

        /**
         * Depth First Search
         */
        private void DFSearch() {

            // If input is not a number, display an error
            if ( !Int32.TryParse( txtValue.Text, out int val ) ) {
                DisplayMsg("Error", "Invalid input. Please enter a numeric value.");
            }
            // Else, search value in graph 1
            else {
                Graph1 g1 = new Graph1();

                // Adjust value to match the index of the matrix then call DFS
                bool result = g1.DFS(0, val - 1);

                if ( result ) {
                    DisplayMsg("Success", val + " is found.");
                }
                else {
                    DisplayMsg("Error", val + " is not found.");
                }
            }
            
            // Clear input box
            txtValue.Text = String.Empty;

            // Disable button
            btnExecute.Enabled = false;
        }

        /**
         * Breadth First Search
         */
        private void BFSearch() {

            if (txtValue.Text.Length > 1) {
                DisplayMsg("Error", "Invalid input. Please enter only one character.");
            }
            else {
                Graph2 g2 = new Graph2();
                
                // Search value entered by the user
                char val = txtValue.Text[0];

                // Adjust value to match the index of the matrix then call BFS
                bool result = g2.BFS(0, char.ToUpper(val) - 65);

                if ( result ) {
                    DisplayMsg("Success", val + " is found.");
                }
                else {
                    DisplayMsg("Error", val + " is not found.");
                }
            }

            // Clear input box
            txtValue.Text = String.Empty;

            // Disable button
            btnExecute.Enabled = false;
        }

        /**
         * Displays message on the screen
         */
        private void DisplayMsg(string type, string msg) {
            if (type == "Success") {
                labelMsg.ForeColor = Color.YellowGreen;
            }
            else {
                labelMsg.ForeColor = Color.Tomato;
            }
            labelMsg.Text = msg;
            labelMsg.Visible = true;
        }
    }

    /**
     * Graph Class
     */
    public class Graph {
        
        // Adjacency Matrix
        protected int[,] Matrix { get; set; }
        
        // No. of vertices
        protected int Size { get; set; }

        // Visited vertices
        protected int[] Visited { get; set; }
        
        // Final order in which the nodes are visited
        public string VisitOrder { get; set; }

        // Stack for DFT and DFS
        protected int[] Stack = new int[100];
        protected int top = 0;

        // Queue for BFT and BFS
        protected int[] Queue = new int[100];
        protected int head = 0;
        protected int tail = 0;

        // Class Constructor
        public Graph() {
            VisitOrder = "";
        }

		/**
         * Depth First Traversal
         */
        public void DFT(int x) {

            // If x has not yet been visited, visit x then push adjacent matrices to the stack
        	ExploreDF(x);

            // If stack is not yet empty, proceed to the next vertex
            if (top > 0) {
                DFT(Stack[--top]);
            }
        }
        
        /**
         * Depth First Search
         */
        public bool DFS(int x, int key) {

            // If key is found, return true
            if (x == key) {
                return true;
            }

            // If x has not yet been visited, visit x then push adjacent matrices to the stack
            ExploreDF(x);

            // If stack is not yet empty, proceed to the next vertex
            if (top > 0) {
                return DFS(Stack[--top], key);
            }
            // Else, key is not on the graph
            else {
                return false;
            }
        }

        /**
         * Check status of the current vertex.
         * If not yet visited, visit vertex then push adjacent vertices to the stack.
         */
        private void ExploreDF(int x) {

			// If x has not yet been visited
            if (Visited[x] == 0) {

                // Save order in which the nodes are visited
                SaveVisitOrder(x);

				// Mark vertex as visited
                Visited[x] = 1;

				// Push adjacent vertices to the stack
	            for (int i = 0; i < Size; i++){
	                if (Matrix[x, i] == 1) {
	                    Stack[top++] = i;
	                }
	            }
            }
		}
        
        /**
         * Breadth First Traversal
         */
        public void BFT(int x) {

            // If x has not yet been visited, visit x then enqueue adjacent matrices to the queue
            ExploreBF(x);

            // If queue is not yet empty, proceed to the next vertex
            if (head < tail) {
                BFT(Queue[head++]);
            }
        }
        
        /**
         * Breadth First Search
         */
        public bool BFS(int x, int key) {

            // If key is found, return true
            if (x == key) {
                return true;
            }

            // If x has not yet been visited, visit x then enqueue adjacent matrices to the queue
            ExploreBF(x);

            // If queue is not yet empty, proceed to the next vertex
            if (head < tail) {
                return BFS(Queue[head++], key);
            }
            // Else, key is not on the graph
            else {
                return false;
            }
        }
        
        /**
         * Check status of the current vertex.
         * If not yet visited, visit vertex then enqueue adjacent vertices to the queue.
         */
		private void ExploreBF(int x) {

            // If x has not yet been visited
            if (Visited[x] == 0) {

                // Save order in which the nodes are visited
                SaveVisitOrder(x);

				// Mark vertex as visited
                Visited[x] = 1;

				// Enqueue adjacent vertices to the queue
	            for (int i = 0; i < Size; i++) {
	                if (Matrix[x, i] == 1) {
	                    Queue[tail++] = i;
	                }
	            }
            }
		}

        /**
         * Override this method in the child class
         */
        protected virtual void SaveVisitOrder(int x) { }
    }

    /**
     * Graph 1 Class
     */
    public class Graph1: Graph {

        /**
         * Class Constructor
         */
        public Graph1() {

            // No. of vertices
            Size = 7;

            // Adjacency matrix for Graph 1
            Matrix = new int[,] {
                { 0, 1, 1, 0, 0, 0, 0},
                { 0, 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 0, 0, 1, 0},
                { 0, 0, 0, 0, 1, 0, 0},
                { 0, 1, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 0, 0, 1},
                { 0, 0, 0, 0, 0, 0, 0}
            };

			// Initialize visited to 0
            Visited = new int[] {0, 0, 0, 0, 0, 0, 0};
        }

        /**
         * Save final order in which the nodes are visited
         */
        protected override void SaveVisitOrder(int x) {
            // Adjust by 1 since the index starts in 0 then save
            VisitOrder += x + 1 + " ";
        }
    }

    /**
     * Graph 2 Class
     */
    public class Graph2: Graph {

        /**
         * Class Constructor
         */
        public Graph2() {

            // No. of vertices
            Size = 5;

            // Adjacency matrix for Graph 2
            Matrix = new int[,] {
                { 0, 1, 0, 0, 0},
                { 0, 0, 0, 0, 1},
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0},
                { 0, 1, 1, 1, 0}
            };

			// Initialize visited to 0
            Visited = new int[] { 0, 0, 0, 0, 0 };
        }

		/**
         * Save final order in which the nodes are visited
         */
        protected override void SaveVisitOrder(int x) {
            // Convert to letter then save
        	VisitOrder += (char)(x + 65) + " ";
        }
    }
}