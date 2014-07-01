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
      return "BaseModel{Id=" + this.Id + "}";
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;

      BaseModel b = obj as BaseModel;
      if (b == null)
        return false;
      
      return this.Id.Equals(b.Id);
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
  }
}
