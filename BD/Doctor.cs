namespace BD
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Doctor
    {
        [Key]
        [Index("Speciality_IdDoctor_IdSpeciality_Index", Order = 0)]
        public int DoctorId { get; set; }

        [DisplayName("Nombre")] public string Name { get; set; }
        [DisplayName("Edad")] public int Age { get; set; }

        #region Foreing Key

        [DisplayName("Especialidad")]
        [Index("Speciality_IdDoctor_IdSpeciality_Index", Order = 1)]
        public int SpecialityId { get; set; }

        #endregion

        #region Virtual
        [JsonIgnore] public virtual Speciality Speciality { get; set; }
        #endregion
    }
}
