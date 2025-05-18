namespace Gererateur_Scenario.Vue
{
    partial class FormGenerateur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listAeroport = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nomAeroport = new System.Windows.Forms.TextBox();
            this.position_latitude = new System.Windows.Forms.TextBox();
            this.position_longitude = new System.Windows.Forms.TextBox();
            this.maxPassager = new System.Windows.Forms.TextBox();
            this.minCargaison = new System.Windows.Forms.TextBox();
            this.minPassager = new System.Windows.Forms.TextBox();
            this.maxCargaison = new System.Windows.Forms.TextBox();
            this.btnAjouterAeroport = new System.Windows.Forms.Button();
            this.listAeronef = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nomAeronef = new System.Windows.Forms.TextBox();
            this.vitesse = new System.Windows.Forms.TextBox();
            this.tempsEmbarquement = new System.Windows.Forms.TextBox();
            this.tempsDebarquement = new System.Windows.Forms.TextBox();
            this.tempsEntretien = new System.Windows.Forms.TextBox();
            this.btnAeronef = new System.Windows.Forms.Button();
            this.btnCharger = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.modifierAeroport = new System.Windows.Forms.Button();
            this.SupprimerAeroport = new System.Windows.Forms.Button();
            this.nouveauScenario = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.capacite = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.ComboBox();
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.capacite = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.SuspendLayout();
            // 
            // listAeroport
            // 
            this.listAeroport.FormattingEnabled = true;
            this.listAeroport.Location = new System.Drawing.Point(10, 13);
            this.listAeroport.Margin = new System.Windows.Forms.Padding(2);
            this.listAeroport.Name = "listAeroport";
            this.listAeroport.Size = new System.Drawing.Size(814, 134);
            this.listAeroport.TabIndex = 0;
            this.listAeroport.SelectedIndexChanged += new System.EventHandler(this.listAeroport_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom  : ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(158, 163);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Position : ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(287, 164);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "minPassager : ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(421, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "maxPassagers : ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(559, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "minCargaison : ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(693, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "maxCargaisons : ";
            // 
            // nomAeroport
            // 
            this.nomAeroport.Location = new System.Drawing.Point(58, 163);
            this.nomAeroport.Margin = new System.Windows.Forms.Padding(2);
            this.nomAeroport.Name = "nomAeroport";
            this.nomAeroport.Size = new System.Drawing.Size(96, 20);
            this.nomAeroport.TabIndex = 7;
            // 
            // position_latitude
            // 
            this.position_latitude.Location = new System.Drawing.Point(213, 164);
            this.position_latitude.Margin = new System.Windows.Forms.Padding(2);
            this.position_latitude.Name = "position_latitude";
            this.position_latitude.Size = new System.Drawing.Size(30, 20);
            this.position_latitude.TabIndex = 8;
            // 
            // position_longitude
            // 
            this.position_longitude.Location = new System.Drawing.Point(247, 164);
            this.position_longitude.Margin = new System.Windows.Forms.Padding(2);
            this.position_longitude.Name = "position_longitude";
            this.position_longitude.Size = new System.Drawing.Size(30, 20);
            this.position_longitude.TabIndex = 9;
            // 
            // maxPassager
            // 
            this.maxPassager.Location = new System.Drawing.Point(508, 167);
            this.maxPassager.Margin = new System.Windows.Forms.Padding(2);
            this.maxPassager.Name = "maxPassager";
            this.maxPassager.Size = new System.Drawing.Size(43, 20);
            this.maxPassager.TabIndex = 10;
            // 
            // minCargaison
            // 
            this.minCargaison.Location = new System.Drawing.Point(638, 167);
            this.minCargaison.Margin = new System.Windows.Forms.Padding(2);
            this.minCargaison.Name = "minCargaison";
            this.minCargaison.Size = new System.Drawing.Size(43, 20);
            this.minCargaison.TabIndex = 11;
            // 
            // minPassager
            // 
            this.minPassager.Location = new System.Drawing.Point(367, 165);
            this.minPassager.Margin = new System.Windows.Forms.Padding(2);
            this.minPassager.Name = "minPassager";
            this.minPassager.Size = new System.Drawing.Size(43, 20);
            this.minPassager.TabIndex = 12;
            // 
            // maxCargaison
            // 
            this.maxCargaison.Location = new System.Drawing.Point(781, 166);
            this.maxCargaison.Margin = new System.Windows.Forms.Padding(2);
            this.maxCargaison.Name = "maxCargaison";
            this.maxCargaison.Size = new System.Drawing.Size(43, 20);
            this.maxCargaison.TabIndex = 13;
            // 
            // btnAjouterAeroport
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.btnAjouterAeroport.Location = new System.Drawing.Point(10, 203);
            this.btnAjouterAeroport.Margin = new System.Windows.Forms.Padding(2);
            this.btnAjouterAeroport.Name = "btnAjouterAeroport";
            this.btnAjouterAeroport.Size = new System.Drawing.Size(290, 27);
=======
            this.btnAjouterAeroport.Location = new System.Drawing.Point(10, 199);
            this.btnAjouterAeroport.Margin = new System.Windows.Forms.Padding(2);
            this.btnAjouterAeroport.Name = "btnAjouterAeroport";
            this.btnAjouterAeroport.Size = new System.Drawing.Size(813, 19);
>>>>>>> Stashed changes
=======
            this.btnAjouterAeroport.Location = new System.Drawing.Point(10, 199);
            this.btnAjouterAeroport.Margin = new System.Windows.Forms.Padding(2);
            this.btnAjouterAeroport.Name = "btnAjouterAeroport";
            this.btnAjouterAeroport.Size = new System.Drawing.Size(813, 19);
>>>>>>> Stashed changes
=======
            this.btnAjouterAeroport.Location = new System.Drawing.Point(10, 199);
            this.btnAjouterAeroport.Margin = new System.Windows.Forms.Padding(2);
            this.btnAjouterAeroport.Name = "btnAjouterAeroport";
            this.btnAjouterAeroport.Size = new System.Drawing.Size(813, 19);
>>>>>>> Stashed changes
            this.btnAjouterAeroport.TabIndex = 14;
            this.btnAjouterAeroport.Text = "Ajouter Aéroport";
            this.btnAjouterAeroport.UseVisualStyleBackColor = true;
            this.btnAjouterAeroport.Click += new System.EventHandler(this.btnAeroport_Click);
            // 
            // listAeronef
            // 
            this.listAeronef.FormattingEnabled = true;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.listAeronef.Location = new System.Drawing.Point(10, 250);
=======
            this.listAeronef.Location = new System.Drawing.Point(10, 239);
>>>>>>> Stashed changes
=======
            this.listAeronef.Location = new System.Drawing.Point(10, 239);
>>>>>>> Stashed changes
=======
            this.listAeronef.Location = new System.Drawing.Point(10, 239);
>>>>>>> Stashed changes
            this.listAeronef.Margin = new System.Windows.Forms.Padding(2);
            this.listAeronef.Name = "listAeronef";
            this.listAeronef.Size = new System.Drawing.Size(814, 134);
            this.listAeronef.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 393);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nom : ";
            // 
            // label8
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.label8.Location = new System.Drawing.Point(153, 393);
=======
            this.label8.Location = new System.Drawing.Point(178, 391);
>>>>>>> Stashed changes
=======
            this.label8.Location = new System.Drawing.Point(178, 391);
>>>>>>> Stashed changes
=======
            this.label8.Location = new System.Drawing.Point(178, 391);
>>>>>>> Stashed changes
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Vitesse : ";
            // 
            // label9
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.label9.Location = new System.Drawing.Point(268, 391);
=======
            this.label9.Location = new System.Drawing.Point(297, 390);
>>>>>>> Stashed changes
=======
            this.label9.Location = new System.Drawing.Point(297, 390);
>>>>>>> Stashed changes
=======
            this.label9.Location = new System.Drawing.Point(297, 390);
>>>>>>> Stashed changes
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "temps embarquement : ";
            // 
            // label10
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.label10.Location = new System.Drawing.Point(445, 392);
=======
            this.label10.Location = new System.Drawing.Point(479, 392);
>>>>>>> Stashed changes
=======
            this.label10.Location = new System.Drawing.Point(479, 392);
>>>>>>> Stashed changes
=======
            this.label10.Location = new System.Drawing.Point(479, 392);
>>>>>>> Stashed changes
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "temps debarquement : ";
            // 
            // label11
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.label11.Location = new System.Drawing.Point(625, 393);
=======
            this.label11.Location = new System.Drawing.Point(682, 392);
>>>>>>> Stashed changes
=======
            this.label11.Location = new System.Drawing.Point(682, 392);
>>>>>>> Stashed changes
=======
            this.label11.Location = new System.Drawing.Point(682, 392);
>>>>>>> Stashed changes
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 19);
            this.label11.TabIndex = 20;
            this.label11.Text = "temps entretien :";
            // 
            // nomAeronef
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.nomAeronef.Location = new System.Drawing.Point(48, 390);
            this.nomAeronef.Margin = new System.Windows.Forms.Padding(2);
            this.nomAeronef.Name = "nomAeronef";
            this.nomAeronef.Size = new System.Drawing.Size(84, 20);
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.nomAeronef.Location = new System.Drawing.Point(58, 391);
            this.nomAeronef.Margin = new System.Windows.Forms.Padding(2);
            this.nomAeronef.Name = "nomAeronef";
            this.nomAeronef.Size = new System.Drawing.Size(110, 20);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.nomAeronef.TabIndex = 21;
            // 
            // vitesse
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.vitesse.Location = new System.Drawing.Point(213, 389);
            this.vitesse.Margin = new System.Windows.Forms.Padding(2);
            this.vitesse.Name = "vitesse";
            this.vitesse.Size = new System.Drawing.Size(35, 20);
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.vitesse.Location = new System.Drawing.Point(239, 391);
            this.vitesse.Margin = new System.Windows.Forms.Padding(2);
            this.vitesse.Name = "vitesse";
            this.vitesse.Size = new System.Drawing.Size(45, 20);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.vitesse.TabIndex = 22;
            // 
            // tempsEmbarquement
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.tempsEmbarquement.Location = new System.Drawing.Point(394, 388);
            this.tempsEmbarquement.Margin = new System.Windows.Forms.Padding(2);
            this.tempsEmbarquement.Name = "tempsEmbarquement";
            this.tempsEmbarquement.Size = new System.Drawing.Size(32, 20);
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.tempsEmbarquement.Location = new System.Drawing.Point(424, 392);
            this.tempsEmbarquement.Margin = new System.Windows.Forms.Padding(2);
            this.tempsEmbarquement.Name = "tempsEmbarquement";
            this.tempsEmbarquement.Size = new System.Drawing.Size(42, 20);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.tempsEmbarquement.TabIndex = 23;
            // 
            // tempsDebarquement
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.tempsDebarquement.Location = new System.Drawing.Point(567, 388);
            this.tempsDebarquement.Margin = new System.Windows.Forms.Padding(2);
            this.tempsDebarquement.Name = "tempsDebarquement";
            this.tempsDebarquement.Size = new System.Drawing.Size(32, 20);
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.tempsDebarquement.Location = new System.Drawing.Point(617, 389);
            this.tempsDebarquement.Margin = new System.Windows.Forms.Padding(2);
            this.tempsDebarquement.Name = "tempsDebarquement";
            this.tempsDebarquement.Size = new System.Drawing.Size(42, 20);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.tempsDebarquement.TabIndex = 24;
            // 
            // tempsEntretien
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.tempsEntretien.Location = new System.Drawing.Point(720, 389);
            this.tempsEntretien.Margin = new System.Windows.Forms.Padding(2);
            this.tempsEntretien.Name = "tempsEntretien";
            this.tempsEntretien.Size = new System.Drawing.Size(36, 20);
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.tempsEntretien.Location = new System.Drawing.Point(777, 389);
            this.tempsEntretien.Margin = new System.Windows.Forms.Padding(2);
            this.tempsEntretien.Name = "tempsEntretien";
            this.tempsEntretien.Size = new System.Drawing.Size(47, 20);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.tempsEntretien.TabIndex = 25;
            // 
            // btnAeronef
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.btnAeronef.Location = new System.Drawing.Point(13, 477);
            this.btnAeronef.Margin = new System.Windows.Forms.Padding(2);
            this.btnAeronef.Name = "btnAeronef";
            this.btnAeronef.Size = new System.Drawing.Size(811, 28);
=======
            this.btnAeronef.Location = new System.Drawing.Point(10, 468);
            this.btnAeronef.Margin = new System.Windows.Forms.Padding(2);
            this.btnAeronef.Name = "btnAeronef";
            this.btnAeronef.Size = new System.Drawing.Size(813, 19);
>>>>>>> Stashed changes
=======
            this.btnAeronef.Location = new System.Drawing.Point(10, 468);
            this.btnAeronef.Margin = new System.Windows.Forms.Padding(2);
            this.btnAeronef.Name = "btnAeronef";
            this.btnAeronef.Size = new System.Drawing.Size(813, 19);
>>>>>>> Stashed changes
=======
            this.btnAeronef.Location = new System.Drawing.Point(10, 468);
            this.btnAeronef.Margin = new System.Windows.Forms.Padding(2);
            this.btnAeronef.Name = "btnAeronef";
            this.btnAeronef.Size = new System.Drawing.Size(813, 19);
>>>>>>> Stashed changes
            this.btnAeronef.TabIndex = 26;
            this.btnAeronef.Text = "Ajouter Aéronef";
            this.btnAeronef.UseVisualStyleBackColor = true;
            // 
            // btnCharger
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.btnCharger.Location = new System.Drawing.Point(13, 508);
            this.btnCharger.Margin = new System.Windows.Forms.Padding(2);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(242, 27);
=======
            this.btnCharger.Location = new System.Drawing.Point(10, 509);
            this.btnCharger.Margin = new System.Windows.Forms.Padding(2);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(405, 20);
>>>>>>> Stashed changes
=======
            this.btnCharger.Location = new System.Drawing.Point(10, 509);
            this.btnCharger.Margin = new System.Windows.Forms.Padding(2);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(405, 20);
>>>>>>> Stashed changes
=======
            this.btnCharger.Location = new System.Drawing.Point(10, 509);
            this.btnCharger.Margin = new System.Windows.Forms.Padding(2);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(405, 20);
>>>>>>> Stashed changes
            this.btnCharger.TabIndex = 27;
            this.btnCharger.Text = "Charger Scenario";
            this.btnCharger.UseVisualStyleBackColor = true;
            this.btnCharger.Click += new System.EventHandler(this.btnCharger_Click);
            // 
            // btnEnregistrer
            // 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.btnEnregistrer.Location = new System.Drawing.Point(520, 509);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(302, 26);
=======
            this.btnEnregistrer.Location = new System.Drawing.Point(418, 509);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(405, 20);
>>>>>>> Stashed changes
=======
            this.btnEnregistrer.Location = new System.Drawing.Point(418, 509);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(405, 20);
>>>>>>> Stashed changes
=======
            this.btnEnregistrer.Location = new System.Drawing.Point(418, 509);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(405, 20);
>>>>>>> Stashed changes
            this.btnEnregistrer.TabIndex = 28;
            this.btnEnregistrer.Text = "Générer Scenario";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // modifierAeroport
            // 
            this.modifierAeroport.Location = new System.Drawing.Point(352, 202);
            this.modifierAeroport.Margin = new System.Windows.Forms.Padding(2);
            this.modifierAeroport.Name = "modifierAeroport";
            this.modifierAeroport.Size = new System.Drawing.Size(152, 28);
            this.modifierAeroport.TabIndex = 29;
            this.modifierAeroport.Text = "ModifierAéroport";
            this.modifierAeroport.UseVisualStyleBackColor = true;
            this.modifierAeroport.Click += new System.EventHandler(this.modifierAeroport_Click);
            // 
            // SupprimerAeroport
            // 
            this.SupprimerAeroport.Location = new System.Drawing.Point(628, 202);
            this.SupprimerAeroport.Margin = new System.Windows.Forms.Padding(2);
            this.SupprimerAeroport.Name = "SupprimerAeroport";
            this.SupprimerAeroport.Size = new System.Drawing.Size(110, 26);
            this.SupprimerAeroport.TabIndex = 30;
            this.SupprimerAeroport.Text = "Supprimer Aéroport";
            this.SupprimerAeroport.UseVisualStyleBackColor = true;
            this.SupprimerAeroport.Click += new System.EventHandler(this.SupprimerAeroport_Click_1);
            // 
            // nouveauScenario
            // 
            this.nouveauScenario.Location = new System.Drawing.Point(310, 509);
            this.nouveauScenario.Margin = new System.Windows.Forms.Padding(2);
            this.nouveauScenario.Name = "nouveauScenario";
            this.nouveauScenario.Size = new System.Drawing.Size(171, 26);
            this.nouveauScenario.TabIndex = 31;
            this.nouveauScenario.Text = "Nouveau Scenario";
            this.nouveauScenario.UseVisualStyleBackColor = true;
            this.nouveauScenario.Click += new System.EventHandler(this.nouveauScenario_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(10, 435);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 19);
            this.label14.TabIndex = 32;
            this.label14.Text = "Type : ";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(176, 435);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 19);
            this.label15.TabIndex = 34;
            this.label15.Text = "Capactie : ";
            // 
            // capacite
            // 
            this.capacite.Location = new System.Drawing.Point(236, 430);
            this.capacite.Margin = new System.Windows.Forms.Padding(2);
            this.capacite.Name = "capacite";
            this.capacite.Size = new System.Drawing.Size(64, 20);
            this.capacite.TabIndex = 35;
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Passager",
            "Cargo",
            "Secours",
            "Citerne",
            "Helicoptere"});
            this.type.Location = new System.Drawing.Point(48, 429);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 21);
            this.type.TabIndex = 36;
            // 
            // capacite
            // 
            this.capacite.Location = new System.Drawing.Point(262, 428);
            this.capacite.Name = "capacite";
            this.capacite.Size = new System.Drawing.Size(100, 20);
            this.capacite.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 431);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 19);
            this.label12.TabIndex = 31;
            this.label12.Text = "Type:";
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Passager",
            "Cargo",
            "Secours",
            "Citerne",
            "Helicoptere"});
            this.type.Location = new System.Drawing.Point(58, 427);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 21);
            this.type.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(201, 431);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 19);
            this.label13.TabIndex = 32;
            this.label13.Text = "Capacite:";
            // 
            // capacite
            // 
            this.capacite.Location = new System.Drawing.Point(262, 428);
            this.capacite.Name = "capacite";
            this.capacite.Size = new System.Drawing.Size(100, 20);
            this.capacite.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 431);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 19);
            this.label12.TabIndex = 31;
            this.label12.Text = "Type:";
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Passager",
            "Cargo",
            "Secours",
            "Citerne",
            "Helicoptere"});
            this.type.Location = new System.Drawing.Point(58, 427);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 21);
            this.type.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(201, 431);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 19);
            this.label13.TabIndex = 32;
            this.label13.Text = "Capacite:";
            // 
            // capacite
            // 
            this.capacite.Location = new System.Drawing.Point(262, 428);
            this.capacite.Name = "capacite";
            this.capacite.Size = new System.Drawing.Size(100, 20);
            this.capacite.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 431);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 19);
            this.label12.TabIndex = 31;
            this.label12.Text = "Type:";
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Passager",
            "Cargo",
            "Secours",
            "Citerne",
            "Helicoptere"});
            this.type.Location = new System.Drawing.Point(58, 427);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 21);
            this.type.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(201, 431);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 19);
            this.label13.TabIndex = 32;
            this.label13.Text = "Capacite:";
            // 
            // FormGenerateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(832, 546);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.Controls.Add(this.type);
            this.Controls.Add(this.capacite);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.nouveauScenario);
            this.Controls.Add(this.SupprimerAeroport);
            this.Controls.Add(this.modifierAeroport);
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.capacite);
            this.Controls.Add(this.type);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnCharger);
            this.Controls.Add(this.btnAeronef);
            this.Controls.Add(this.tempsEntretien);
            this.Controls.Add(this.tempsDebarquement);
            this.Controls.Add(this.tempsEmbarquement);
            this.Controls.Add(this.vitesse);
            this.Controls.Add(this.nomAeronef);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listAeronef);
            this.Controls.Add(this.btnAjouterAeroport);
            this.Controls.Add(this.maxCargaison);
            this.Controls.Add(this.minPassager);
            this.Controls.Add(this.minCargaison);
            this.Controls.Add(this.maxPassager);
            this.Controls.Add(this.position_longitude);
            this.Controls.Add(this.position_latitude);
            this.Controls.Add(this.nomAeroport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listAeroport);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormGenerateur";
            this.Text = "Générateur de scenario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button nouveauScenario;

        private System.Windows.Forms.Button SupprimerAeroport;

        private System.Windows.Forms.Button modifierAeroport;

        private System.Windows.Forms.Button btnCharger;
        private System.Windows.Forms.Button btnEnregistrer;

        private System.Windows.Forms.Button btnAeronef;

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox nomAeronef;
        private System.Windows.Forms.TextBox vitesse;
        private System.Windows.Forms.TextBox tempsEmbarquement;
        private System.Windows.Forms.TextBox tempsDebarquement;
        private System.Windows.Forms.TextBox tempsEntretien;

        private System.Windows.Forms.ListBox listAeronef;

        private System.Windows.Forms.Button btnAjouterAeroport;

        private System.Windows.Forms.TextBox maxCargaison;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nomAeroport;
        private System.Windows.Forms.TextBox position_latitude;
        private System.Windows.Forms.TextBox position_longitude;
        private System.Windows.Forms.TextBox maxPassager;
        private System.Windows.Forms.TextBox minCargaison;
        private System.Windows.Forms.TextBox minPassager;

        private System.Windows.Forms.ListBox listAeroport;

        #endregion

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox capacite;
        private System.Windows.Forms.ComboBox type;
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        private System.Windows.Forms.TextBox capacite;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label label13;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}