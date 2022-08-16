using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Tela.AlunoTela
{
    public static class UpdateAlunoTela
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um aluno");
            Console.WriteLine("-------------");
            Console.Write("Qual CPF Do aluno que deseja Atualizar? ");
            var cpf = Console.ReadLine();

            var alunoRepository = new AlunoRepository(Database.Connection);
            var alunos = alunoRepository.GetWithCPF(cpf);
            //alunos.Nome = 'nome'
            // var repository = new Repository<Aluno>(Database.Connection);
            // var alunos = repository.Get(cpf);
            
            Console.WriteLine("Qual Campo deseja Atualizar?");
            Console.WriteLine("-----------------");
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - E-mail");
            Console.WriteLine("3 - CPF");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Digine um novo nome: ");
                    string novoNome = Console.ReadLine();
                    alunos.Nome = novoNome;
                    Update(alunos, alunoRepository);
                    break;
                case 2:
                    Console.WriteLine("Digite um novo email: ");
                    string novoEmail = Console.ReadLine();
                    alunos.Email = novoEmail;
                    Update(alunos, alunoRepository);
                    break;
                case 3:
                    Console.WriteLine("Digite um novo CPF: ");
                    string novoCpf = Console.ReadLine();
                    alunos.CPF = novoCpf;
                    Update(alunos, alunoRepository);
                    break;
                default: break;
            }
            Console.ReadKey();
            MenuAlunoTela.Load();
        }


        
        public static void Update(Aluno aluno, AlunoRepository repository)
        {
            try
            {
                repository.Update(aluno);
                Console.WriteLine("Aluno atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a aluno");
                Console.WriteLine(ex.Message);
            }
        }
    }
}