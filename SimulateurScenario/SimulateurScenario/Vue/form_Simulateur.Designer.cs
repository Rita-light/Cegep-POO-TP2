using System.ComponentModel;

namespace SimulateurScenario;

partial class form_Simulateur
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Simulateur));
        groupBox1 = new System.Windows.Forms.GroupBox();
        charger_scenario = new System.Windows.Forms.Button();
        groupBox2 = new System.Windows.Forms.GroupBox();
        listAeroport = new System.Windows.Forms.ListBox();
        Horloge = new System.Windows.Forms.GroupBox();
        groupBox4 = new System.Windows.Forms.GroupBox();
        groupBox3 = new System.Windows.Forms.GroupBox();
        listClient = new System.Windows.Forms.ListBox();
        carte = new System.Windows.Forms.Panel();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(charger_scenario);
        groupBox1.Location = new System.Drawing.Point(1, 7);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(977, 71);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Action Simelation";
        // 
        // charger_scenario
        // 
        charger_scenario.Location = new System.Drawing.Point(19, 27);
        charger_scenario.Name = "charger_scenario";
        charger_scenario.Size = new System.Drawing.Size(198, 30);
        charger_scenario.TabIndex = 0;
        charger_scenario.Text = "Charger scenario";
        charger_scenario.UseVisualStyleBackColor = true;
        charger_scenario.Click += charger_scenario_Click;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(listAeroport);
        groupBox2.Location = new System.Drawing.Point(7, 101);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(241, 215);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "Aéroport";
        // 
        // listAeroport
        // 
        listAeroport.FormattingEnabled = true;
        listAeroport.Location = new System.Drawing.Point(0, 23);
        listAeroport.Name = "listAeroport";
        listAeroport.Size = new System.Drawing.Size(241, 184);
        listAeroport.TabIndex = 0;
        // 
        // Horloge
        // 
        Horloge.Location = new System.Drawing.Point(360, 894);
        Horloge.Name = "Horloge";
        Horloge.Size = new System.Drawing.Size(258, 68);
        Horloge.TabIndex = 5;
        Horloge.TabStop = false;
        Horloge.Text = "Horloge";
        // 
        // groupBox4
        // 
        groupBox4.Location = new System.Drawing.Point(637, 101);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new System.Drawing.Size(328, 213);
        groupBox4.TabIndex = 3;
        groupBox4.TabStop = false;
        groupBox4.Text = "Aeronef";
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(listClient);
        groupBox3.Location = new System.Drawing.Point(254, 101);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(377, 214);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        groupBox3.Text = "Client";
        // 
        // listClient
        // 
        listClient.FormattingEnabled = true;
        listClient.Location = new System.Drawing.Point(9, 31);
        listClient.Name = "listClient";
        listClient.Size = new System.Drawing.Size(368, 164);
        listClient.TabIndex = 0;
        // 
        // carte
        // 
        carte.BackgroundImage = ((System.Drawing.Image)resources.GetObject("carte.BackgroundImage"));
        carte.Location = new System.Drawing.Point(7, 333);
        carte.Name = "carte";
        carte.Size = new System.Drawing.Size(960, 540);
        carte.TabIndex = 6;
        // 
        // form_Simulateur
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(970, 971);
        Controls.Add(carte);
        Controls.Add(Horloge);
        Controls.Add(groupBox4);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Text = "form_Simulateur";
        Load += form_Simulateur_Load;
        groupBox1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel carte;

    private System.Windows.Forms.ListBox listClient;

    private System.Windows.Forms.ListBox listAeroport;

    private System.Windows.Forms.Button charger_scenario;

    private System.Windows.Forms.GroupBox Horloge;


    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox4;

    #endregion
}