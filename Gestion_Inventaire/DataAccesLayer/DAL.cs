using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Inventaire.Models;
using Gestion_Inventaire.DataAccesLayer.Factories;


namespace Gestion_Inventaire.DataAccesLayer
{
    public class DAL
    {
        public static string? ConnectionString { get; set; }
        private EquipementFactory? _equipementFact = null;
        private CourseFact? _courseFact = null;
        private LocalFact? _localFact = null;
        private MarkFact? _markFact = null;
        private ScheduleFact? _scheduleFact = null;
        private SpecificityFact? _specificityFact = null;
        private TeacherFact? _teacherFact = null;
        private TypeFact? _typeFact = null;
        private DepartementFact? _departementFact = null;
        
        public EquipementFactory EquipementFact
        {
            get
            {
                if(_equipementFact == null)
                {
                    _equipementFact= new EquipementFactory();
                }
                return _equipementFact;
            }
        }

        public CourseFact CourseFact
        {
            get
            {
                if (_courseFact == null)
                {
                    _courseFact = new CourseFact();
                }
                return _courseFact;
            }
        }

        public LocalFact LocalFact
        {
            get
            {
                if (_localFact == null)
                {
                    _localFact = new LocalFact();
                }
                return _localFact;
            }
        }

        public MarkFact MarkFact
        {
            get
            {
                if (_markFact == null)
                {
                    _markFact = new MarkFact();
                }
                return _markFact;
            }
        }

        public ScheduleFact ScheduleFact
        {
            get
            {
                if (_scheduleFact == null)
                {
                    _scheduleFact = new ScheduleFact();
                }
                return _scheduleFact;
            }
        }

        public SpecificityFact SpecificityFact
        {
            get
            {
                if (_specificityFact == null)
                {
                    _specificityFact = new SpecificityFact();
                }
                return _specificityFact;
            }
        }

        public TeacherFact TeacherFact
        {
            get
            {
                if (_teacherFact == null)
                {
                    _teacherFact = new TeacherFact();
                }
                return _teacherFact;
            }
        }

        public TypeFact TypeFact
        {
            get
            {
                if (_typeFact == null)
                {
                    _typeFact = new TypeFact();
                }
                return _typeFact;
            }
        }

        public DepartementFact DepartementFact

        {
            get
            {
                if (_departementFact == null)
                {
                    _departementFact = new DepartementFact();
                }
                return _departementFact;
            }
        }
    }
}
