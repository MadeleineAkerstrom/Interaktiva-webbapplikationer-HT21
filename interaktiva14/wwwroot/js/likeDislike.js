function LikeFunction(imdbId, id) {
    likeButton = document.getElementById("likebutton" + id)    
    likeButton.disabled = true
    
    url = "https://grupp9.dsvkurs.miun.se/api/Movie/"+imdbId+"/like"
    fetch(url).
    then(response => response.json())
    .then(data => {
      document.getElementById('number-of-likes-' + id).innerHTML = "Number of Likes: " + data['numberOfLikes']
      console.log(data)
    }).finally(() => setTimeout(() => {likeButton.disabled = false;}, 3000));
  }

function DislikeFunction(imdbId, id) {
    dislikeButton = document.getElementById("dislikebutton" + id)
    dislikeButton.disabled = true
    
    url = "https://grupp9.dsvkurs.miun.se/api/Movie/"+imdbId+"/dislike"
    fetch(url).
    then(response => response.json())
    .then(data => {
      document.getElementById('number-of-dislikes-' + id).innerHTML = "Number of Dislikes: " + data['numberOfDislikes']
      console.log(data)
    })
    .finally(() => setTimeout(() => {dislikeButton.disabled = false;}, 3000));
  }