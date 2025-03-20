using System;
using System.Collections.Generic;
using FinancialAccounting.Domain.Factories;
using FinancialAccounting.DataAccess;
using FinancialAccounting.Domain;
using FinancialAccounting.Domain.Services;
using FinancialAccounting.Commands;
using FinancialAccounting.ImportExport;
using FinancialAccounting.Extensions;

namespace FinancialAccounting
{
    class Program
    {
        static void Main()
        {
            var factory = new DomainFactory();
            var bankAccountRepoCore = new InMemoryRepository<BankAccount>(x => x.Id);
            var bankAccountRepoProxy = new InMemoryRepositoryProxy<BankAccount>(bankAccountRepoCore, x => x.Id);
            var categoryRepoCore = new InMemoryRepository<Category>(x => x.Id);
            var categoryRepoProxy = new InMemoryRepositoryProxy<Category>(categoryRepoCore, x => x.Id);
            var operationRepoCore = new InMemoryRepository<Operation>(x => x.Id);
            var operationRepoProxy = new InMemoryRepositoryProxy<Operation>(operationRepoCore, x => x.Id);

            var bankAccountFacade = new BankAccountFacade(bankAccountRepoProxy);
            var categoryFacade = new CategoryFacade(categoryRepoProxy);
            var operationFacade = new OperationFacade(operationRepoProxy, bankAccountRepoProxy);
            var analyticsFacade = new AnalyticsFacade(operationRepoProxy, categoryRepoProxy);

            var commands = new List<ICommand>
            {
                new CreateBankAccountCommand(bankAccountFacade, factory),
                new ListBankAccountsCommand(bankAccountFacade),
                new CreateCategoryCommand(categoryFacade, factory),
                new CreateOperationCommand(operationFacade, factory),
                new ListOperationsCommand(operationFacade)
            };

            while (true)
            {
                Console.WriteLine("\n1. " + commands[0].CommandName);
                Console.WriteLine("2. " + commands[1].CommandName);
                Console.WriteLine("3. " + commands[2].CommandName);
                Console.WriteLine("4. " + commands[3].CommandName);
                Console.WriteLine("5. " + commands[4].CommandName);
                Console.WriteLine("A. Разница доходов и расходов");
                Console.WriteLine("B. Группировка по категориям");
                Console.WriteLine("X. Экспорт данных");
                Console.WriteLine("Q. Выход");
                var choice = Console.ReadLine();
                if (choice == null) continue;
                if (choice.ToUpper() == "Q") break;

                if (int.TryParse(choice, out var cmdIndex) && cmdIndex >= 1 && cmdIndex <= commands.Count)
                {
                    var cmd = new CommandTimeMeasureDecorator(commands[cmdIndex - 1]);
                    cmd.Execute();
                }
                else
                {
                    switch (choice.ToUpper())
                    {
                        case "A":
                            Console.Write("Дата начала (yyyy-MM-dd): ");
                            var startA = DateTime.Parse(Console.ReadLine());
                            Console.Write("Дата конца (yyyy-MM-dd): ");
                            var endA = DateTime.Parse(Console.ReadLine());
                            var diff = analyticsFacade.GetIncomeMinusExpense(startA, endA);
                            Console.WriteLine("Разница: " + diff);
                            break;
                        case "B":
                            Console.Write("Дата начала (yyyy-MM-dd): ");
                            var startB = DateTime.Parse(Console.ReadLine());
                            Console.Write("Дата конца (yyyy-MM-dd): ");
                            var endB = DateTime.Parse(Console.ReadLine());
                            Console.Write("Тип (доход/расход): ");
                            var opType = Console.ReadLine();
                            var dict = analyticsFacade.GetAmountByCategory(startB, endB, opType);
                            foreach (var kvp in dict)
                            {
                                Console.WriteLine(kvp.Key + ": " + kvp.Value);
                            }
                            break;
                        case "X":
                            var csvVisitor = new CsvExportVisitor();
                            var jsonVisitor = new JsonExportVisitor();
                            var yamlVisitor = new YamlExportVisitor();

                            foreach (var acc in bankAccountFacade.GetAllAccounts())
                            {
                                acc.Accept(csvVisitor, jsonVisitor, yamlVisitor);
                            }
                            foreach (var cat in categoryFacade.GetAllCategories())
                            {
                                cat.Accept(csvVisitor, jsonVisitor, yamlVisitor);
                            }
                            foreach (var op in operationFacade.GetAllOperations())
                            {
                                op.Accept(csvVisitor, jsonVisitor, yamlVisitor);
                            }

                            Console.WriteLine("=== CSV ===");
                            Console.WriteLine(csvVisitor.GetResult());
                            Console.WriteLine("=== JSON ===");
                            Console.WriteLine(jsonVisitor.GetResult());
                            Console.WriteLine("=== YAML ===");
                            Console.WriteLine(yamlVisitor.GetResult());
                            break;
                    }
                }
            }
        }
    }
}
