
namespace DevStory.Interfaces
{
    public interface IDroppable
    {

        //Method to be fired when the dragger successfully drops the element.
        //Method not to be attached in the dragger itself, but on the dragger object
        void Drop();
    }
}
