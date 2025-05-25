using SimulateurScenario.Controleur;
using SimulateurScenario.Model;

namespace SimulateurScenario;

public partial class form_Simulateur : Form, IObservateur
{
    private ControleurSimulateur controleur;

    public form_Simulateur()
    {
        InitializeComponent();
    }

    public void SetControleur(ControleurSimulateur ctrl)
    {
        this.controleur = ctrl;
    }

    public void Notifier(Evenement e)
    {
        MessageBox.Show($"Nouvel évènement");
        if (e.typeEvenement == TypeEvenement.ChargementTermine)
        {
            AfficherAeroportsDansListe(e.Aeroports);
          AfficherAeroportsSurCarte(e.Aeroports);
          //AfficherAeroportsSurCarte(e.Aeroports, pictureBoxCarte, Image.FromFile("icone_aeroport.png"));

        }
        
    }
    
    private void AfficherAeroportsDansListe(List<Aeroport> aeroports)
    {
        listAeroport.Items.Clear();
        foreach (var aeroport in aeroports)
        {
            listAeroport.Items.Add(aeroport.Nom);
        }
    }
    
    public void AfficherAeroportsSurCarte(List<Aeroport> aeroports)
    {
        foreach (var aeroport in aeroports)
        {
            // Conversion des coordonnées
            Point positionPixel = Position.ConvertirCoordonneesEnPixels(aeroport.Position);
            Console.WriteLine($"Aéroport: {aeroport.Nom} - Coordonnées: {aeroport.Position.Latitude}, {aeroport.Position.Longitude}");
            Console.WriteLine($"Aéroport: {aeroport.Nom} - Coordonnées pixel: {positionPixel.X}, {positionPixel.Y}");

            // Création du marqueur image
            PictureBox marqueur = new PictureBox
            {
                Image = Image.FromFile("icone_aeroport.png"),
                Size = new Size(30, 30),
                Location = positionPixel,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Création du label pour le nom
            Label labelNom = new Label
            {
                Text = aeroport.Nom,
                Location = new Point(positionPixel.X + 35, positionPixel.Y+5),
                AutoSize = true,
                BackColor = Color.Transparent,
                ForeColor = Color.Black // Ou blanc selon la carte
            };

            // Ajout des contrôles sur la carte
            carte.Controls.Add(marqueur);
            carte.Controls.Add(labelNom);

            // Mettre au premier plan si besoin
            marqueur.BringToFront();
            labelNom.BringToFront();
        }
        
        
    }
    
    

    







    

    private void form_Simulateur_Load(object sender, EventArgs e)
    {
        HorlogeNumerique horloge = new HorlogeNumerique();
        horloge.Location = new Point(10, 20); // Dans le GroupBox
        Horloge.Controls.Add(horloge);
    }

    private void carte_Click(object sender, EventArgs e)
    {

    }

    private void charger_scenario_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";
        openFileDialog.Title = "Importer un scénario";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string cheminFichier = openFileDialog.FileName;
            try
            {
                controleur.ChargerScenario(cheminFichier);
                MessageBox.Show("Succès de l'importation "  ,"validation",
                    MessageBoxButtons.OK);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'importation du scénario : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}