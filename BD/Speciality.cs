namespace BD
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Speciality
    {
        [Key]
        public int SpecialityId { get; set; }

        [DisplayName("Nombre de la especialidad")]
        [StringLength(50)]
        [Index("Speciality_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        #region Virtual
        [JsonIgnore]
        public virtual ICollection<Doctor> Doctors { get; set; }
        #endregion
    }
}
