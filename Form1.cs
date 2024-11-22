using System.Runtime.InteropServices;

namespace Senai.WF.Viru
{
    public partial class Form1 : Form
    {
        // variaveis
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        // metodo que executa o evento de clique
        [DllImport("user32.dll",
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
            int dwFlags,
            int dx,
            int dy,
            int cButtons,
            int dwExtraInfo);
        // Gera numeros aleatorios
        private Random random = new();

        private void MoverCursorMouse()
        {
            // Obter largura da tela = 1360
            int largura = Screen.PrimaryScreen.Bounds.Width;
            // Obter altura da tela = 768
            int altura = Screen.PrimaryScreen.Bounds.Height;
            //Gerar uma posicao aleatoria X
            int posX = random.Next(largura);
            //Gerar uma posicao aleatoria Y
            int posY = random.Next(altura);
            // Posicionar o cursor do mouse na posicao X,Y
            Cursor.Position = new Point(posX, posY);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoverCursorMouse();

            //loop de 1 ate 10
            // repetição de 10 x 
            for (int i = 1; i <= 10; i++)
            {
                MoverCursorMouse();
                Clicar();
                //Clicar();
                // esperar 100 milisegundos
                Thread.Sleep(1000);

            }
        }

        private void Clicar()
        {
            // Executa o clique completo do mouse
            // Pressiona o botão esquerdo
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            // Solta o botão esquerdo
            mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }
    }
}
