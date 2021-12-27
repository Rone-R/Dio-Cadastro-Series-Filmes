namespace Dio_Series
{
    public class Serie : EntityBase
    {
        #region Fields Private
        private Genders Genders { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }
        #endregion

        #region Fields public
        public int GetId => this.Id;
        public string GetTitle => this.Title;
        public int GetYear => this.Year;
        public bool IsDeleted => this.Deleted;
        #endregion
        public Serie(int id, Genders genders, string title, string description, int year)
        {
            this.Id = id;
            this.Genders = genders;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        #region Customs
        public override string ToString()
        {
            string retorn = "";
            retorn += "Gender: " + this.Genders + Environment.NewLine;
            retorn += "Title: " + this.Title + Environment.NewLine;
            retorn += "Description: " + this.Description + Environment.NewLine;
            retorn += "Year: " + this.Year + Environment.NewLine;
            retorn += "Deleted: " + this.Deleted + Environment.NewLine;
            return retorn;
        }
        public void Delete()
        {
            this.Deleted = true;
        }
        #endregion
    }
}