namespace Cotizador.Migrations
{
    using Cotizador.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cotizador.Models.DBCotizador>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Cotizador.Models.DBCotizador context)
        {            
            Brand brand1 = new Brand();
            brand1.BrandName = "Toyota";
            context.Brands.Add(brand1);

            Model model1 = new Model();
            model1.Brand = brand1;
            model1.BrandId = brand1.Id;
            model1.ModelName = "Corola";
            context.Mdoels.Add(model1);

            Year year1 = new Year();
            year1.Model = model1;
            year1.ModelId = model1.Id;
            year1.YearName = "2019";
            context.Years.Add(year1);

            Year year2 = new Year();
            year2.Model = model1;
            year2.ModelId = model1.Id;
            year2.YearName = "2020";
            context.Years.Add(year2);

            Model model2 = new Model();
            model2.Brand = brand1;
            model2.BrandId = brand1.Id;
            model2.ModelName = "Prius";
            context.Mdoels.Add(model2);

            Year year3 = new Year();
            year3.Model = model2;
            year3.ModelId = model2.Id;
            year3.YearName = "2017";
            context.Years.Add(year3);

            Year year4 = new Year();
            year4.Model = model2;
            year4.ModelId = model2.Id;
            year4.YearName = "2018";
            context.Years.Add(year4);

            Brand brand2 = new Brand();
            brand2.BrandName = "Mazda";
            context.Brands.Add(brand2);

            Model model3 = new Model();
            model3.Brand = brand2;
            model3.BrandId = brand2.Id;
            model3.ModelName = "Mazda 3";
            context.Mdoels.Add(model3);

            Year year5 = new Year();
            year5.Model = model3;
            year5.ModelId = model3.Id;
            year5.YearName = "2016";
            context.Years.Add(year5);

            Year year6 = new Year();
            year6.Model = model3;
            year6.ModelId = model3.Id;
            year6.YearName = "2018";
            context.Years.Add(year6);

            Model model4 = new Model();
            model4.Brand = brand2;
            model4.BrandId = brand2.Id;
            model4.ModelName = "Mazda 6";
            context.Mdoels.Add(model4);

            Year year7 = new Year();
            year7.Model = model4;
            year7.ModelId = model4.Id;
            year7.YearName = "2016";
            context.Years.Add(year7);

            Year year8 = new Year();
            year8.Model = model4;
            year8.ModelId = model4.Id;
            year8.YearName = "2018";
            context.Years.Add(year8);

            Brand brand3 = new Brand();
            brand3.BrandName = "Volkswagen";            
            context.Brands.Add(brand3);

            Model model5 = new Model();
            model5.Brand = brand3;
            model5.BrandId = brand3.Id;
            model5.ModelName = "Jetta";
            context.Mdoels.Add(model5);

            Year year9 = new Year();
            year9.Model = model5;
            year9.ModelId = model5.Id;
            year9.YearName = "2010";
            context.Years.Add(year9);

            Year year10 = new Year();
            year10.Model = model5;
            year10.ModelId = model5.Id;
            year10.YearName = "2012";
            context.Years.Add(year10);

            Model model6 = new Model();
            model6.Brand = brand3;
            model6.BrandId = brand3.Id;
            model6.ModelName = "Vento";
            context.Mdoels.Add(model6);

            Year year11 = new Year();
            year11.Model = model6;
            year11.ModelId = model6.Id;
            year11.YearName = "2010";
            context.Years.Add(year11);

            Year year12 = new Year();
            year12.Model = model6;
            year12.ModelId = model6.Id;
            year12.YearName = "2012";
            context.Years.Add(year12);

            Setting MinPrice = new Setting();
            MinPrice.Description = "Monto mínimo a solicitar";
            MinPrice.Value = "100000";
            context.Settings.Add(MinPrice);

            Setting MaxPrice = new Setting();
            MaxPrice.Description = "Monto máximo a solicitar";
            MaxPrice.Value = "1000000";
            context.Settings.Add(MaxPrice);

            Setting Porcentaje = new Setting();
            Porcentaje.Description = "Porcentaje de enganche mínimo";
            Porcentaje.Value = "20";
            context.Settings.Add(Porcentaje);

            base.Seed(context);

        }
    }
}
