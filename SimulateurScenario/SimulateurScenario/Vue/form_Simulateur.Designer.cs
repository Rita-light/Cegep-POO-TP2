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
        listAeronef = new System.Windows.Forms.ListBox();
        groupBox3 = new System.Windows.Forms.GroupBox();
        listClient = new System.Windows.Forms.ListBox();
        carte = new System.Windows.Forms.Panel();
        groupBox5 = new System.Windows.Forms.GroupBox();
        nombrePas = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        avancerPluspas = new System.Windows.Forms.Button();
        AvancerPas = new System.Windows.Forms.Button();
        btnStopAuto = new System.Windows.Forms.Button();
        btnStartAuto = new System.Windows.Forms.Button();
        btn_redemarrer = new System.Windows.Forms.Button();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox4.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox5.SuspendLayout();
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
        groupBox2.Size = new System.Drawing.Size(241, 188);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "Aéroport";
        // 
        // listAeroport
        // 
        listAeroport.FormattingEnabled = true;
        listAeroport.Location = new System.Drawing.Point(0, 23);
        listAeroport.Name = "listAeroport";
        listAeroport.Size = new System.Drawing.Size(241, 144);
        listAeroport.TabIndex = 0;
        listAeroport.SelectedIndexChanged += listAeroport_SelectedIndexChanged;
        // 
        // Horloge
        // 
        Horloge.Location = new System.Drawing.Point(984, 747);
        Horloge.Name = "Horloge";
        Horloge.Size = new System.Drawing.Size(245, 68);
        Horloge.TabIndex = 5;
        Horloge.TabStop = false;
        Horloge.Text = "Horloge";
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(listAeronef);
        groupBox4.Location = new System.Drawing.Point(637, 101);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new System.Drawing.Size(328, 188);
        groupBox4.TabIndex = 3;
        groupBox4.TabStop = false;
        groupBox4.Text = "Aeronef";
        // 
        // listAeronef
        // 
        listAeronef.FormattingEnabled = true;
        listAeronef.Location = new System.Drawing.Point(15, 18);
        listAeronef.Name = "listAeronef";
        listAeronef.Size = new System.Drawing.Size(313, 144);
        listAeronef.TabIndex = 0;
        listAeronef.SelectedIndexChanged += listAeronef_SelectedIndexChanged;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(listClient);
        groupBox3.Location = new System.Drawing.Point(254, 101);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(377, 188);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        groupBox3.Text = "Client";
        // 
        // listClient
        // 
        listClient.FormattingEnabled = true;
        listClient.Location = new System.Drawing.Point(9, 31);
        listClient.Name = "listClient";
        listClient.Size = new System.Drawing.Size(368, 144);
        listClient.TabIndex = 0;
        // 
        // carte
        // 
        carte.Anchor = System.Windows.Forms.AnchorStyles.None;
        carte.BackgroundImage = ((System.Drawing.Image)resources.GetObject("carte.BackgroundImage"));
        carte.Location = new System.Drawing.Point(7, 338);
        carte.Name = "carte";
        carte.Size = new System.Drawing.Size(960, 540);
        carte.TabIndex = 6;
        // 
        // groupBox5
        // 
        groupBox5.Controls.Add(btn_redemarrer);
        groupBox5.Controls.Add(nombrePas);
        groupBox5.Controls.Add(label1);
        groupBox5.Controls.Add(avancerPluspas);
        groupBox5.Controls.Add(AvancerPas);
        groupBox5.Controls.Add(btnStopAuto);
        groupBox5.Controls.Add(btnStartAuto);
        groupBox5.Location = new System.Drawing.Point(984, 16);
        groupBox5.Name = "groupBox5";
        groupBox5.Size = new System.Drawing.Size(278, 668);
        groupBox5.TabIndex = 7;
        groupBox5.TabStop = false;
        groupBox5.Text = "groupBox5";
        // 
        // nombrePas
        // 
        nombrePas.Location = new System.Drawing.Point(32, 383);
        nombrePas.Name = "nombrePas";
        nombrePas.Size = new System.Drawing.Size(213, 27);
        nombrePas.TabIndex = 5;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(42, 329);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(139, 31);
        label1.TabIndex = 4;
        label1.Text = "Nombre de pas :";
        // 
        // avancerPluspas
        // 
        avancerPluspas.Location = new System.Drawing.Point(32, 442);
        avancerPluspas.Name = "avancerPluspas";
        avancerPluspas.Size = new System.Drawing.Size(213, 68);
        avancerPluspas.TabIndex = 3;
        avancerPluspas.Text = "Avancer plusieur pas";
        avancerPluspas.UseVisualStyleBackColor = true;
        avancerPluspas.Click += avancerPluspas_Click;
        // 
        // AvancerPas
        // 
        AvancerPas.Location = new System.Drawing.Point(32, 232);
        AvancerPas.Name = "AvancerPas";
        AvancerPas.Size = new System.Drawing.Size(213, 72);
        AvancerPas.TabIndex = 2;
        AvancerPas.Text = "Avancer d\'un pas";
        AvancerPas.UseVisualStyleBackColor = true;
        AvancerPas.Click += AvancerPas_Click;
        // 
        // btnStopAuto
        // 
        btnStopAuto.Location = new System.Drawing.Point(32, 123);
        btnStopAuto.Name = "btnStopAuto";
        btnStopAuto.Size = new System.Drawing.Size(213, 60);
        btnStopAuto.TabIndex = 1;
        btnStopAuto.Text = "Arreter Simulation Auto";
        btnStopAuto.UseVisualStyleBackColor = true;
        btnStopAuto.Click += btnStopAuto_Click;
        // 
        // btnStartAuto
        // 
        btnStartAuto.Location = new System.Drawing.Point(32, 40);
        btnStartAuto.Name = "btnStartAuto";
        btnStartAuto.Size = new System.Drawing.Size(213, 59);
        btnStartAuto.TabIndex = 0;
        btnStartAuto.Text = "Demarer simulation auto";
        btnStartAuto.UseVisualStyleBackColor = true;
        btnStartAuto.Click += btnStartAuto_Click;
        // 
        // btn_redemarrer
        // 
        btn_redemarrer.Location = new System.Drawing.Point(32, 561);
        btn_redemarrer.Name = "btn_redemarrer";
        btn_redemarrer.Size = new System.Drawing.Size(213, 69);
        btn_redemarrer.TabIndex = 6;
        btn_redemarrer.Text = "Redemarrer Scenario";
        btn_redemarrer.UseVisualStyleBackColor = true;
        btn_redemarrer.Click += btn_redemarrer_Click;
        // 
        // form_Simulateur
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoSize = true;
        ClientSize = new System.Drawing.Size(1281, 920);
        Controls.Add(groupBox5);
        Controls.Add(carte);
        Controls.Add(Horloge);
        Controls.Add(groupBox4);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        Text = "form_Simulateur";
        Load += form_Simulateur_Load;
        groupBox1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        groupBox4.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        groupBox5.ResumeLayout(false);
        groupBox5.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btn_redemarrer;

    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.Button btnStartAuto;
    private System.Windows.Forms.Button btnStopAuto;
    private System.Windows.Forms.Button AvancerPas;
    private System.Windows.Forms.Button avancerPluspas;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox nombrePas;

    private System.Windows.Forms.ListBox listAeronef;

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