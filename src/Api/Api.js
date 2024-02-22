import service from '../service.js'
import qs from 'qs'


export default function login(data) {
    return service({
        method: 'post',
        url: '/User/login',
        data
    })
}


export  function SongAll(data) {
    return service({
        method: 'get',
        url: '/Songs/GetAll',
        data
    })
}

export  function AlbumAll(data) {
    return service({
        method: 'get',
        url: '/Album/GetAll',
        data
    })
}

export  function ArtistAll(data) {
    return service({
        method: 'get',
        url: '/Artist/GetAll',
        data
    })
}



export  function SongName(Title) {
    return service({
        method: 'post',
        url: `/Songs/GetSongName/${Title}`,
        Title
    })
}

export  function ArtistName(Name) {
    return service({
        method: 'post',
        url: `/Artist/SelectName/${Name}`,
        Name
    })
}


export  function SongGenre(Genre) {
    return service({
        method: 'post',
        url: `/Songs/GetGenre/${Genre}`,
        Genre
    })
}

export  function SongArtist(Artist) {
    return service({
        method: 'post',
        url: `/Songs/GetArtist/${Artist}`,
        Artist
    })
}
export  function SongAlbum(Album) {
    return service({
        method: 'post',
        url: `/Songs/GetAlbum/${Album}`,
        Album
    })
}

export  function SongDelete(Title) {
    return service({
        method: 'delete',
        url: `/Songs/DeleteOne/${Title}`,
        Title
    })
}

export function Songinfo(data) {
    return service({
        method: 'post',
        url: '/Songs/InsertSong',
        data: data,
        headers: {
            'Content-Type': 'application/json'
        }
    });
}

     export function SongUpdate(data) {
        
        return service({
            method: 'post',
            url: '/Songs/UpdateSong',
            data:data,
            headers: {
                'Content-Type': 'application/json'
            }
        });
    }  


  

