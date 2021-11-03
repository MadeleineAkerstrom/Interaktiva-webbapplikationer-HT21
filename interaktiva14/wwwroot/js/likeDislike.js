function LikeFunction(imdbId) {
    likeButton = document.getElementById("likebutton0")
    likeButton.disabled = true
    //likeButton.style.background='#000000'
    
    url = "https://grupp9.dsvkurs.miun.se/api/Movie/"+imdbId+"/like"
    fetch(url).
    then(response => response.json())
    .then(data => console.log(data)).finally(() => (likeButton.disabled = false));
  }

function DislikeFunction() {
    url = "https://grupp9.dsvkurs.miun.se/api/Movie/tt0111161/dislike"
    fetch(url)
.then(response => response.json())
.then(data => console.log(data));
}