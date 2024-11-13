namespace Darag_Cassaforte
{
    public partial class Form1 : Form
    {
        Cassaforte cassa = new Cassaforte("123", "prodottore", "modello", "123456789123");
        int conta;
        public Form1()
        {
            InitializeComponent();
            conta = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string codice = textBox1.Text;
            cassa.Imposta_codice(codice);
            textBox1.Visible = false;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string codice_1 = textBox2.Text;
            cassa.Apri(codice_1);
            conta = conta + 1;
            if (conta>5)
            {
                textBox2.Visible = false ;
                MessageBox.Show("5 tentativi esauriti");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cassa.Chiudi(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cassa.Sblocca(textBox4.Text);
        }
    }
}
class Cassaforte
{
    private string num_matricola;
    public string Num_matricola
    {
        get { return num_matricola; }
    }
    private string prodottore;
    public string Prodottore
    {
        get { return prodottore; }

    }
    private string modello;
    public string Modello
    {
        get { return modello; }
    }
    private string codice_sblocco;
    public string Codice_sblocco
    {
        get { return codice_sblocco; }
    }
    private bool stato;
    public bool Stato
    {
        get { return stato; }

    }

    public Cassaforte(string num_matricola, string prodottore, string modello, string codice_sblocco)
    {
        this.num_matricola = num_matricola;
        this.prodottore = prodottore;
        this.modello = modello;
        this.codice_sblocco = codice_sblocco;
    }
    private string codice_5;

    public void Imposta_codice(string codice)
    {

        if (codice.Length == 5)
        {
            this.codice_5 = codice;
        }
        else
        {
            MessageBox.Show("il codice inserito non è valido! ");
        }

    }
    private int giusto;
    public int Giusto
    {
        get { return giusto; }
    }
    public void Apri(string codice)
    {
        if (codice_5.Length != codice.Length)
        {
            MessageBox.Show("codice non valido!");
        }
        else
        {
            for (int i = 0; i < codice_5.Length; i++)
            {
                if (codice[i] != codice_5[i])
                {
                    MessageBox.Show("codice non corretto");
                    giusto = 1;
                    break;
                }
            }
        }
    }
    public void Chiudi(string codice)
    {
        stato = false;
        Imposta_codice(codice);
    }

    public void Sblocca(string codice_12)
    {
        if (codice_12.Length < 13)
        {
            MessageBox.Show("codice non valido");
        }
        else
        {
            for (int i = 0; i < codice_12.Length; i++)
            {
                if (codice_12[i] != codice_sblocco[i])
                {
                    MessageBox.Show("codice non corretto");
                    break;
                }

            }
            MessageBox.Show("codice corretto");
        }
    }
}