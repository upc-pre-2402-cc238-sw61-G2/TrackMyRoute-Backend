using backend.Promos.Domain.Model.Commands;

namespace backend.Promos.Domain.Model.Aggregates;

public class Promo
{
    public int Id { get; }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    //Promo has image
    //public string image { get; }

    protected Promo()
    {
        this.Title = string.Empty;
        this.Description = string.Empty;
    }

    public Promo(CreatePromoCommand command)
    {
        this.Title = command.Title;
        this.Description = command.Description;
    }
    
}