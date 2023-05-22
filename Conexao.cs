using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TesteOxxy
{
    internal class Conexao
    {
        public string conec = "SERVER=localhost; DATABASE=oxxyteste; UID=root; PWD=; PORT=;";

        public MySqlConnection con = null;

        public void AbrirConexao()
        {
            con = new MySqlConnection(conec);
            con.Open();

        }

        public void FecharConexao()
        {
            con = new MySqlConnection(conec);
            con.Close();
            con.Dispose(); //derrubar algumas conexoes abertas
            con.ClearAllPoolsAsync(); // metodo de limpeza
        }
    }
}
