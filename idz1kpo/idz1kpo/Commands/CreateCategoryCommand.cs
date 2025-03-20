using System;
using FinancialAccounting.Domain.Factories;
using FinancialAccounting.Domain.Services;

namespace FinancialAccounting.Commands
{
    public class CreateCategoryCommand : ICommand
    {
        private readonly CategoryFacade _facade;
        private readonly IDomainFactory _factory;

        public CreateCategoryCommand(CategoryFacade facade, IDomainFactory factory)
        {
            _facade = facade;
            _factory = factory;
        }

        public string CommandName => "Создать категорию";

        public void Execute()
        {
            Console.Write("Введите название категории: ");
            var name = Console.ReadLine();
            Console.Write("Введите тип (доход/расход): ");
            var type = Console.ReadLine();
            var cat = _factory.CreateCategory(type, name);
            _facade.Create(cat);
            Console.WriteLine("Категория создана. Id=" + cat.Id);
        }
    }
}