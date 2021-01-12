using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageSpecialResearch.Models
{
    public class TestResult
    {
        [Required]
        public int Id { get; set; }//Guid - глобальный идентификатор

        [Required]
        [Display(Name = "Оборудование")]
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        [Display(Name = "Результат испытания")]
        public string Manufacturer { get; set; }

        [Display(Name = "Интерфейс")]
        public int InterfaceId { get; set; }
        public Interface Interface { get; set; }

        [Display(Name = "Сигнал обнаружен")]
        public string SignalFound { get; set; }

        [Display(Name = "Тест пройден")]
        public string OperatingMode { get; set; }

        [Display(Name = "Дата проведения испытания")]
        public DateTime Date { get; set; }

        [Display(Name = "Тип испытания")]
        public int TestTypeId { get; set; }
        public TestType TestType { get; set; }
    }
}
