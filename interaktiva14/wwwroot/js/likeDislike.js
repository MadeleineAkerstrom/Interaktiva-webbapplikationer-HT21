function LikeFunction(imdbId, id) {
    likeButton = document.getElementById("likebutton" + id)
   // document.getElementById('number-of-likes-0').innerHTML = 'test'
    
    likeButton.disabled = true
    //likeButton.style.background='#000000'
    
    url = "https://grupp9.dsvkurs.miun.se/api/Movie/"+imdbId+"/like"
    fetch(url).
    then(response => response.json())
    .then(data => console.log(data)).finally(() => (likeButton.disabled = false));
    
  }

function DislikeFunction(imdbId, id) {
    dislikeButton = document.getElementById("dislikebutton" + id)
    dislikeButton.disabled = true
    //likeButton.style.background='#000000'
    
    url = "https://grupp9.dsvkurs.miun.se/api/Movie/"+imdbId+"/dislike"
    fetch(url).
    then(response => response.json())
    .then(data => console.log(data)).finally(() => (dislikeButton.disabled = false));
  }