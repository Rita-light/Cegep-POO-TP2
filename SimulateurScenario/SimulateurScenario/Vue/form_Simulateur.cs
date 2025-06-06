﻿using SimulateurScenario.Controleur;
using SimulateurScenario.Model;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SimulateurScenario;

public partial class form_Simulateur : Form, IObservateur
{
    private ControleurSimulateur controleur;
    private Dictionary<string, Aeroport> nomVersAeroport = new Dictionary<string, Aeroport>();
    private Dictionary<Aeronef, PictureBox> marqueurAeronef = new();
    private Dictionary<Aeronef, Timer> timerDeplacement = new();
    private Dictionary<Evenement, PictureBox> marqueurEvenement = new Dictionary<Evenement, PictureBox>();


    public form_Simulateur()
    {
        InitializeComponent();
        //FacadeSimulateur.EvenementTermine(evenement);

    }
    public PictureBox GetMarqueurAeronef(Aeronef aeronef)
    {
        return marqueurAeronef.ContainsKey(aeronef) ? marqueurAeronef[aeronef] : null;
    }
    public void LancerDeplacement(Aeronef aeronef)
    {
        if (!marqueurAeronef.ContainsKey(aeronef))
        {
            PictureBox pic= new PictureBox
            {
                Image = Image.FromFile("icone_aeronef.png"),
                Size = new Size(30, 30),
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            carte.Controls.Add(pic);
            marqueurAeronef[aeronef] = pic;
        }

        Timer timer = new Timer();
        timer.Interval = 50;
        double progression = 0;
        const double vitesse = 0.01;

        timer.Tick += (s, e) =>
        {
            progression += vitesse;
            if (progression >= 1)
            {
                progression = 1;
                timer.Stop();
                aeronef.ChangerEtat(TypeEtat.Sol);
            }

            aeronef.MettreAJourPosition(progression);
            Point positionPixel = Position.ConvertirCoordonneesEnPixels(aeronef.PositionActuelle);
            marqueurAeronef[aeronef].Location = positionPixel;
        };
        timerDeplacement[aeronef] = timer;
        timer.Start();
    }

    public void SupprimerMarqueurEvenement(Evenement evenement)
    {
        if (marqueurEvenement.TryGetValue(evenement, out PictureBox pic))
        {
            carte.Controls.Remove(pic);
            pic.Dispose();
            marqueurEvenement.Remove(evenement);
            Console.WriteLine($"[Vue] Marqueur supprimé pour l'événement : {evenement.typeEvenement} à {evenement.position}");
        }
    }

    
    public void SetControleur(ControleurSimulateur ctrl)
    {
        this.controleur = ctrl;
    }

    public void Notifier(Evenement e)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Notifier(e)));
            return;
        }

        if (e == null) return;

        if (e.EstTermine)
        {
            SupprimerMarqueurEvenement(e);
            return;
        }

        switch (e.typeEvenement)
        {
            case TypeEvenement.ChargementTermine:
                AfficherAeroportsDansListe(e.Aeroports);
                AfficherAeroportsSurCarte(e.Aeroports);
                break;

            case TypeEvenement.Secours:
            case TypeEvenement.Incendie:
            case TypeEvenement.Observation:

                AfficherEvenementSurCarte(e);
                controleur.TraiterEvenement(e);
                
                break;

            case TypeEvenement.NouveauClient:
                AfficherAeroportsDansListe(e.Aeroports);
                break;
        }

    }

    private void AfficherAeroportsDansListe(List<Aeroport> aeroports)
    {
        listAeroport.Items.Clear();
        nomVersAeroport.Clear();

        foreach (Aeroport a in aeroports)
        {
            listAeroport.Items.Add(a.Nom);
            nomVersAeroport[a.Nom] = a;
        }
    }

    public void AfficherAeroportsSurCarte(List<Aeroport> aeroports)
    {
        foreach (var aeroport in aeroports)
        {
            // Conversion des coordonnées
            Point positionPixel = Position.ConvertirCoordonneesEnPixels(aeroport.Position);
            
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
                Location = new Point(positionPixel.X + 35, positionPixel.Y + 5),
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

    public void AfficherEvenementSurCarte(Evenement e)
    {

        if (e.position == null) return;

        // Déterminer l’icône à utiliser
        string cheminImage = e.typeEvenement switch
        {
            TypeEvenement.Secours => "icone_secours.png",
            TypeEvenement.Incendie => "icone_incendie.png",
            TypeEvenement.Observation => "icone_observation.png",
            _ => null
        };

        if (cheminImage == null) return;

        // Conversion des coordonnées géographiques en pixels
        Point positionPixel = Position.ConvertirCoordonneesEnPixels(e.position);

        // Création du marqueur image
        PictureBox marqueur = new PictureBox
        {
            Image = Image.FromFile(cheminImage),
            Size = new Size(30, 30),
            Location = positionPixel,
            BackColor = Color.Transparent,
            SizeMode = PictureBoxSizeMode.StretchImage
        };


        // Ajout sur la carte
        carte.Controls.Add(marqueur);
        marqueur.BringToFront();
        
        marqueurEvenement[e] = marqueur;
    }

    private void form_Simulateur_Load(object sender, EventArgs e)
    {
        HorlogeNumerique horloge = new HorlogeNumerique();
        horloge.Location = new Point(10, 20); // Dans le GroupBox
        Horloge.Controls.Add(horloge);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'importation du scénario : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void listAeroport_SelectedIndexChanged(object sender, EventArgs e)
    {
        string nomSelectionne = listAeroport.SelectedItem?.ToString().Trim();
        if (nomSelectionne != null && nomVersAeroport.ContainsKey(nomSelectionne))
        {
            Aeroport aeroport = nomVersAeroport[nomSelectionne];
            Console.WriteLine("Detail aéropor");
            AfficherAeronefs(aeroport);
            AfficherClients(aeroport);
        }
        else
        {
            Console.WriteLine("pas aéropor");
        }
    }

    private void AfficherAeronefs(Aeroport aeroport)
    {
        listAeronef.Items.Clear();

        foreach (Aeronef a in aeroport.Aeronefs)
        {
            listAeronef.Items.Add(a.Nom); // ou $"{a.GetType().Name} - {a.nom}" si tu veux le type aussi
        }
    }

    private void AfficherClients(Aeroport aeroport)
    {
        listClient.Items.Clear();

        // Groupement : Dictionnaire de (Type, Destination) → nombre
        var regroupement = new Dictionary<string, int>();

        foreach (Client c in aeroport.Clients)
        {
            string typeClient = c switch
            {
                Passager => "Passager",
                Cargo => "Cargo",
                _ => "Autre"
            };

            string destination = "";

            if (c is Passager p)
                destination = p.Destination.Nom;
            else if (c is Cargo g)
                destination = g.Destination.Nom;

            string cle = $"{typeClient} → {destination}";

            if (regroupement.ContainsKey(cle))
                regroupement[cle]++;
            else
                regroupement[cle] = 1;
        }

        // Affichage
        foreach (var item in regroupement)
        {
            listClient.Items.Add($"{item.Value} {item.Key}");
        }
    }
    

    public static void ExecuterUI(Control control, Action action)
    {
        if (control.InvokeRequired)
            control.Invoke(action);
        else
            action();
    }

    private void listAeronef_SelectedIndexChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void btnStartAuto_Click(object sender, EventArgs e)
    {
        ActiverBoutonsPas(false);
        controleur.DemarrerSimulationAuto();

    }

    public void ActiverBoutonsPas(bool actif)
    {
        AvancerPas.Enabled = actif;
        avancerPluspas.Enabled = actif;
    }

    private void btnStopAuto_Click(object sender, EventArgs e)
    {
        ActiverBoutonsPas(true);
        controleur.ArreterSimulation();
    }

    private void AvancerPas_Click(object sender, EventArgs e)
    {
        controleur.AvancerUnPas();
    }

    private void avancerPluspas_Click(object sender, EventArgs e)
    {

        if (int.TryParse(nombrePas.Text, out int nbPas) && nbPas > 0)
        {
            controleur.AvancerPlusieursPas(nbPas);
        }
        else
        {
            MessageBox.Show("Veuillez entrer un nombre de pas valide.");
        }
    }

    private void btn_redemarrer_Click(object sender, EventArgs e)
    {
        carte.Controls.Clear();
        listAeronef.Items.Clear();
        listClient.Items.Clear();
        listAeroport.Items.Clear();
        controleur.Reinitialiserscenario();
        MessageBox.Show("Scenario remis à zéro");
        
    }
}