using System;

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
            this.modifierAeroport = new System.Windows.Forms.Button();
            this.SupprimerAeroport = new System.Windows.Forms.Button();
            this.nouveauScenario = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.capacite = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.btnChangerFrequence = new System.Windows.Forms.Button();
            this.typeEvenement = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.frequence = new System.Windows.Forms.TextBox();
            this.suuprimerAeronef = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.etat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listAeroport
            // 
            this.listAeroport.FormattingEnabled = true;
            this.listAeroport.ItemHeight = 16;
            this.listAeroport.Location = new System.Drawing.Point(13, 16);
            this.listAeroport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listAeroport.Name = "listAeroport";
            this.listAeroport.Size = new System.Drawing.Size(1084, 164);
            this.listAeroport.TabIndex = 0;
            this.listAeroport.SelectedIndexChanged += new System.EventHandler(this.listAeroport_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom  : ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(211, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Position : ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(383, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "minPassager : ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(561, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "maxPassagers : ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(745, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "minCargaison : ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(924, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "maxCargaisons : ";
            // 
            // nomAeroport
            // 
            this.nomAeroport.Location = new System.Drawing.Point(77, 201);
            this.nomAeroport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nomAeroport.Name = "nomAeroport";
            this.nomAeroport.Size = new System.Drawing.Size(127, 22);
            this.nomAeroport.TabIndex = 7;
            // 
            // position_latitude
            // 
            this.position_latitude.Location = new System.Drawing.Point(284, 202);
            this.position_latitude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.position_latitude.Name = "position_latitude";
            this.position_latitude.Size = new System.Drawing.Size(39, 22);
            this.position_latitude.TabIndex = 8;
            // 
            // position_longitude
            // 
            this.position_longitude.Location = new System.Drawing.Point(329, 202);
            this.position_longitude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.position_longitude.Name = "position_longitude";
            this.position_longitude.Size = new System.Drawing.Size(39, 22);
            this.position_longitude.TabIndex = 9;
            // 
            // maxPassager
            // 
            this.maxPassager.Location = new System.Drawing.Point(677, 206);
            this.maxPassager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxPassager.Name = "maxPassager";
            this.maxPassager.Size = new System.Drawing.Size(56, 22);
            this.maxPassager.TabIndex = 10;
            // 
            // minCargaison
            // 
            this.minCargaison.Location = new System.Drawing.Point(851, 206);
            this.minCargaison.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minCargaison.Name = "minCargaison";
            this.minCargaison.Size = new System.Drawing.Size(56, 22);
            this.minCargaison.TabIndex = 11;
            // 
            // minPassager
            // 
            this.minPassager.Location = new System.Drawing.Point(489, 203);
            this.minPassager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minPassager.Name = "minPassager";
            this.minPassager.Size = new System.Drawing.Size(56, 22);
            this.minPassager.TabIndex = 12;
            // 
            // maxCargaison
            // 
            this.maxCargaison.Location = new System.Drawing.Point(1041, 204);
            this.maxCargaison.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxCargaison.Name = "maxCargaison";
            this.maxCargaison.Size = new System.Drawing.Size(56, 22);
            this.maxCargaison.TabIndex = 13;
            // 
            // btnAjouterAeroport
            // 
            this.btnAjouterAeroport.Location = new System.Drawing.Point(13, 250);
            this.btnAjouterAeroport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAjouterAeroport.Name = "btnAjouterAeroport";
            this.btnAjouterAeroport.Size = new System.Drawing.Size(387, 33);
            this.btnAjouterAeroport.TabIndex = 14;
            this.btnAjouterAeroport.Text = "Ajouter Aéroport";
            this.btnAjouterAeroport.UseVisualStyleBackColor = true;
            this.btnAjouterAeroport.Click += new System.EventHandler(this.btnAeroport_Click);
            // 
            // listAeronef
            // 
            this.listAeronef.FormattingEnabled = true;
            this.listAeronef.ItemHeight = 16;
            this.listAeronef.Location = new System.Drawing.Point(13, 308);
            this.listAeronef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listAeronef.Name = "listAeronef";
            this.listAeronef.Size = new System.Drawing.Size(1084, 164);
            this.listAeronef.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 484);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nom : ";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(204, 484);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Vitesse : ";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(357, 481);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "temps embarquement : ";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(593, 482);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "temps debarquement : ";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(833, 484);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 23);
            this.label11.TabIndex = 20;
            this.label11.Text = "temps entretien :";
            // 
            // nomAeronef
            // 
            this.nomAeronef.Location = new System.Drawing.Point(64, 480);
            this.nomAeronef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nomAeronef.Name = "nomAeronef";
            this.nomAeronef.Size = new System.Drawing.Size(111, 22);
            this.nomAeronef.TabIndex = 21;
            // 
            // vitesse
            // 
            this.vitesse.Location = new System.Drawing.Point(284, 479);
            this.vitesse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vitesse.Name = "vitesse";
            this.vitesse.Size = new System.Drawing.Size(45, 22);
            this.vitesse.TabIndex = 22;
            // 
            // tempsEmbarquement
            // 
            this.tempsEmbarquement.Location = new System.Drawing.Point(525, 478);
            this.tempsEmbarquement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tempsEmbarquement.Name = "tempsEmbarquement";
            this.tempsEmbarquement.Size = new System.Drawing.Size(41, 22);
            this.tempsEmbarquement.TabIndex = 23;
            // 
            // tempsDebarquement
            // 
            this.tempsDebarquement.Location = new System.Drawing.Point(756, 478);
            this.tempsDebarquement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tempsDebarquement.Name = "tempsDebarquement";
            this.tempsDebarquement.Size = new System.Drawing.Size(41, 22);
            this.tempsDebarquement.TabIndex = 24;
            // 
            // tempsEntretien
            // 
            this.tempsEntretien.Location = new System.Drawing.Point(960, 479);
            this.tempsEntretien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tempsEntretien.Name = "tempsEntretien";
            this.tempsEntretien.Size = new System.Drawing.Size(47, 22);
            this.tempsEntretien.TabIndex = 25;
            // 
            // btnAeronef
            // 
            this.btnAeronef.Location = new System.Drawing.Point(13, 587);
            this.btnAeronef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAeronef.Name = "btnAeronef";
            this.btnAeronef.Size = new System.Drawing.Size(497, 34);
            this.btnAeronef.TabIndex = 26;
            this.btnAeronef.Text = "Ajouter Aéronef";
            this.btnAeronef.UseVisualStyleBackColor = true;
            this.btnAeronef.Click += new System.EventHandler(this.btnAeronef_Click);
            // 
            // btnCharger
            // 
            this.btnCharger.Location = new System.Drawing.Point(17, 720);
            this.btnCharger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(323, 33);
            this.btnCharger.TabIndex = 27;
            this.btnCharger.Text = "Charger Scenario";
            this.btnCharger.UseVisualStyleBackColor = true;
            this.btnCharger.Click += new System.EventHandler(this.btnCharger_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(696, 720);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(403, 32);
            this.btnEnregistrer.TabIndex = 28;
            this.btnEnregistrer.Text = "Générer Scenario";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // modifierAeroport
            // 
            this.modifierAeroport.Location = new System.Drawing.Point(469, 249);
            this.modifierAeroport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modifierAeroport.Name = "modifierAeroport";
            this.modifierAeroport.Size = new System.Drawing.Size(203, 34);
            this.modifierAeroport.TabIndex = 29;
            this.modifierAeroport.Text = "ModifierAéroport";
            this.modifierAeroport.UseVisualStyleBackColor = true;
            this.modifierAeroport.Click += new System.EventHandler(this.modifierAeroport_Click);
            // 
            // SupprimerAeroport
            // 
            this.SupprimerAeroport.Location = new System.Drawing.Point(837, 249);
            this.SupprimerAeroport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SupprimerAeroport.Name = "SupprimerAeroport";
            this.SupprimerAeroport.Size = new System.Drawing.Size(147, 32);
            this.SupprimerAeroport.TabIndex = 30;
            this.SupprimerAeroport.Text = "Supprimer Aéroport";
            this.SupprimerAeroport.UseVisualStyleBackColor = true;
            this.SupprimerAeroport.Click += new System.EventHandler(this.SupprimerAeroport_Click_1);
            // 
            // nouveauScenario
            // 
            this.nouveauScenario.Location = new System.Drawing.Point(408, 720);
            this.nouveauScenario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nouveauScenario.Name = "nouveauScenario";
            this.nouveauScenario.Size = new System.Drawing.Size(228, 32);
            this.nouveauScenario.TabIndex = 31;
            this.nouveauScenario.Text = "Nouveau Scenario";
            this.nouveauScenario.UseVisualStyleBackColor = true;
            this.nouveauScenario.Click += new System.EventHandler(this.nouveauScenario_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(13, 535);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 23);
            this.label14.TabIndex = 32;
            this.label14.Text = "Type : ";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(235, 535);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 23);
            this.label15.TabIndex = 34;
            this.label15.Text = "Capactie : ";
            // 
            // capacite
            // 
            this.capacite.Location = new System.Drawing.Point(315, 529);
            this.capacite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.capacite.Name = "capacite";
            this.capacite.Size = new System.Drawing.Size(84, 22);
            this.capacite.TabIndex = 35;
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] { "Passager", "Cargo", "Secours", "Citerne", "Helicoptere" });
            this.type.Location = new System.Drawing.Point(64, 528);
            this.type.Margin = new System.Windows.Forms.Padding(4);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(160, 24);
            this.type.TabIndex = 36;
            this.type.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // btnChangerFrequence
            // 
            this.btnChangerFrequence.Location = new System.Drawing.Point(597, 640);
            this.btnChangerFrequence.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangerFrequence.Name = "btnChangerFrequence";
            this.btnChangerFrequence.Size = new System.Drawing.Size(228, 33);
            this.btnChangerFrequence.TabIndex = 47;
            this.btnChangerFrequence.Text = "Mettre fréquences à jour";
            this.btnChangerFrequence.UseVisualStyleBackColor = true;
            this.btnChangerFrequence.Click += new System.EventHandler(this.btnChangerFrequence_Click);
            // 
            // typeEvenement
            // 
            this.typeEvenement.FormattingEnabled = true;
            this.typeEvenement.Items.AddRange(new object[] { Gererateur_Scenario.TypeEvenement.Passager, Gererateur_Scenario.TypeEvenement.Cargaison, Gererateur_Scenario.TypeEvenement.Secours, Gererateur_Scenario.TypeEvenement.Incendie, Gererateur_Scenario.TypeEvenement.Observation });
            this.typeEvenement.Location = new System.Drawing.Point(163, 645);
            this.typeEvenement.Margin = new System.Windows.Forms.Padding(4);
            this.typeEvenement.Name = "typeEvenement";
            this.typeEvenement.Size = new System.Drawing.Size(160, 24);
            this.typeEvenement.TabIndex = 48;
            this.typeEvenement.SelectedIndexChanged += new System.EventHandler(this.typeEvenement_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(383, 649);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 17);
            this.label12.TabIndex = 49;
            this.label12.Text = "Fréquence";
            // 
            // frequence
            // 
            this.frequence.Location = new System.Drawing.Point(469, 645);
            this.frequence.Margin = new System.Windows.Forms.Padding(4);
            this.frequence.Name = "frequence";
            this.frequence.Size = new System.Drawing.Size(59, 22);
            this.frequence.TabIndex = 50;
            // 
            // suuprimerAeronef
            // 
            this.suuprimerAeronef.Location = new System.Drawing.Point(578, 587);
            this.suuprimerAeronef.Name = "suuprimerAeronef";
            this.suuprimerAeronef.Size = new System.Drawing.Size(499, 34);
            this.suuprimerAeronef.TabIndex = 51;
            this.suuprimerAeronef.Text = "Supprimer Aeronef";
            this.suuprimerAeronef.UseVisualStyleBackColor = true;
            this.suuprimerAeronef.Click += new System.EventHandler(this.suuprimerAeronef_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(445, 528);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 23);
            this.label13.TabIndex = 52;
            this.label13.Text = "Etat :";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 0;
            // 
            // etat
            // 
            this.etat.FormattingEnabled = true;
            this.etat.Items.AddRange(new object[] { Gererateur_Scenario.TypeEtat.Entretien, Gererateur_Scenario.TypeEtat.Debarquement, Gererateur_Scenario.TypeEtat.Embarquement, Gererateur_Scenario.TypeEtat.Sol, Gererateur_Scenario.TypeEtat.Vol });
            this.etat.Location = new System.Drawing.Point(510, 529);
            this.etat.Margin = new System.Windows.Forms.Padding(4);
            this.etat.Name = "etat";
            this.etat.Size = new System.Drawing.Size(160, 24);
            this.etat.TabIndex = 53;
            this.etat.SelectedIndexChanged += new System.EventHandler(this.etat_SelectedIndexChanged);
            // 
            // FormGenerateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1113, 767);
            this.Controls.Add(this.etat);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.suuprimerAeronef);
            this.Controls.Add(this.frequence);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.typeEvenement);
            this.Controls.Add(this.btnChangerFrequence);
            this.Controls.Add(this.type);
            this.Controls.Add(this.capacite);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.nouveauScenario);
            this.Controls.Add(this.SupprimerAeroport);
            this.Controls.Add(this.modifierAeroport);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormGenerateur";
            this.Text = "Générateur de scenario";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox etat;

        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.Label label13;

        private System.Windows.Forms.Button suuprimerAeronef;

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

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox capacite;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Button btnChangerFrequence;
        private System.Windows.Forms.ComboBox typeEvenement;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox frequence;
    }
}