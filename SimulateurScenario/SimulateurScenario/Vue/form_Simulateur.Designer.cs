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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(form_Simulateur));
        groupBox1 = new GroupBox();
        charger_scenario = new Button();
        groupBox2 = new GroupBox();
        listAeroport = new ListBox();
        Horloge = new GroupBox();
        groupBox4 = new GroupBox();
        listAeronef = new ListBox();
        groupBox3 = new GroupBox();
        listClient = new ListBox();
        carte = new Panel();
        groupBox5 = new GroupBox();
        nombrePas = new TextBox();
        label1 = new Label();
        avancerPluspas = new Button();
        AvancerPas = new Button();
        btnStopAuto = new Button();
        btnStartAuto = new Button();
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
        groupBox1.Location = new Point(1, 7);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(977, 71);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Action Simelation";
        // 
        // charger_scenario
        // 
        charger_scenario.Location = new Point(19, 27);
        charger_scenario.Name = "charger_scenario";
        charger_scenario.Size = new Size(198, 30);
        charger_scenario.TabIndex = 0;
        charger_scenario.Text = "Charger scenario";
        charger_scenario.UseVisualStyleBackColor = true;
        charger_scenario.Click += charger_scenario_Click;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(listAeroport);
        groupBox2.Location = new Point(7, 101);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(241, 188);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "Aéroport";
        // 
        // listAeroport
        // 
        listAeroport.FormattingEnabled = true;
        listAeroport.Location = new Point(0, 23);
        listAeroport.Name = "listAeroport";
        listAeroport.Size = new Size(241, 144);
        listAeroport.TabIndex = 0;
        listAeroport.SelectedIndexChanged += listAeroport_SelectedIndexChanged;
        // 
        // Horloge
        // 
        Horloge.Location = new Point(984, 747);
        Horloge.Name = "Horloge";
        Horloge.Size = new Size(245, 68);
        Horloge.TabIndex = 5;
        Horloge.TabStop = false;
        Horloge.Text = "Horloge";
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(listAeronef);
        groupBox4.Location = new Point(637, 101);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(328, 188);
        groupBox4.TabIndex = 3;
        groupBox4.TabStop = false;
        groupBox4.Text = "Aeronef";
        // 
        // listAeronef
        // 
        listAeronef.FormattingEnabled = true;
        listAeronef.Location = new Point(15, 18);
        listAeronef.Name = "listAeronef";
        listAeronef.Size = new Size(313, 144);
        listAeronef.TabIndex = 0;
        listAeronef.SelectedIndexChanged += listAeronef_SelectedIndexChanged;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(listClient);
        groupBox3.Location = new Point(254, 101);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(377, 188);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        groupBox3.Text = "Client";
        // 
        // listClient
        // 
        listClient.FormattingEnabled = true;
        listClient.Location = new Point(9, 31);
        listClient.Name = "listClient";
        listClient.Size = new Size(368, 144);
        listClient.TabIndex = 0;
        // 
        // carte
        // 
        carte.Anchor = AnchorStyles.None;
        carte.BackgroundImage = (Image)resources.GetObject("carte.BackgroundImage");
        carte.Location = new Point(7, 338);
        carte.Name = "carte";
        carte.Size = new Size(960, 540);
        carte.TabIndex = 6;
        // 
        // groupBox5
        // 
        groupBox5.Controls.Add(nombrePas);
        groupBox5.Controls.Add(label1);
        groupBox5.Controls.Add(avancerPluspas);
        groupBox5.Controls.Add(AvancerPas);
        groupBox5.Controls.Add(btnStopAuto);
        groupBox5.Controls.Add(btnStartAuto);
        groupBox5.Location = new Point(984, 16);
        groupBox5.Name = "groupBox5";
        groupBox5.Size = new Size(278, 668);
        groupBox5.TabIndex = 7;
        groupBox5.TabStop = false;
        groupBox5.Text = "groupBox5";
        // 
        // nombrePas
        // 
        nombrePas.Location = new Point(32, 383);
        nombrePas.Name = "nombrePas";
        nombrePas.Size = new Size(213, 27);
        nombrePas.TabIndex = 5;
        // 
        // label1
        // 
        label1.Location = new Point(42, 329);
        label1.Name = "label1";
        label1.Size = new Size(139, 31);
        label1.TabIndex = 4;
        label1.Text = "Nombre de pas :";
        // 
        // avancerPluspas
        // 
        avancerPluspas.Location = new Point(32, 442);
        avancerPluspas.Name = "avancerPluspas";
        avancerPluspas.Size = new Size(213, 68);
        avancerPluspas.TabIndex = 3;
        avancerPluspas.Text = "Avancer plusieur pas";
        avancerPluspas.UseVisualStyleBackColor = true;
        avancerPluspas.Click += avancerPluspas_Click;
        // 
        // AvancerPas
        // 
        AvancerPas.Location = new Point(32, 232);
        AvancerPas.Name = "AvancerPas";
        AvancerPas.Size = new Size(213, 72);
        AvancerPas.TabIndex = 2;
        AvancerPas.Text = "Avancer d'un pas";
        AvancerPas.UseVisualStyleBackColor = true;
        AvancerPas.Click += AvancerPas_Click;
        // 
        // btnStopAuto
        // 
        btnStopAuto.Location = new Point(32, 123);
        btnStopAuto.Name = "btnStopAuto";
        btnStopAuto.Size = new Size(213, 60);
        btnStopAuto.TabIndex = 1;
        btnStopAuto.Text = "Arreter Simulation Auto";
        btnStopAuto.UseVisualStyleBackColor = true;
        btnStopAuto.Click += btnStopAuto_Click;
        // 
        // btnStartAuto
        // 
        btnStartAuto.Location = new Point(32, 40);
        btnStartAuto.Name = "btnStartAuto";
        btnStartAuto.Size = new Size(213, 59);
        btnStartAuto.TabIndex = 0;
        btnStartAuto.Text = "Demarer simulation auto";
        btnStartAuto.UseVisualStyleBackColor = true;
        btnStartAuto.Click += btnStartAuto_Click;
        // 
        // form_Simulateur
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        ClientSize = new Size(1281, 920);
        Controls.Add(groupBox5);
        Controls.Add(carte);
        Controls.Add(Horloge);
        Controls.Add(groupBox4);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Margin = new Padding(3, 2, 3, 2);
        Name = "form_Simulateur";
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