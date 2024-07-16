using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVM>>
    {
        public string _UserName { get; set; } = string.Empty;
        public GetVideosListQuery( string username)
        {
            this._UserName = username ?? throw new ArgumentNullException (nameof(username)) ;
        }
    }
}
