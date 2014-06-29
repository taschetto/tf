namespace Examiner.Business.Models
{
  public abstract class BaseModel
  {
    public BaseModel(int id)
    {
      this.Id = id;
    }

    public int Id { get; private set; }

    public override string ToString()
    {
      return "BaseModel{id=" + this.Id + "}";
    }
  }
}
