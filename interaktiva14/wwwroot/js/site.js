// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

  function likeFunction()
  {
    console.log(test)
    const request = new Request('https://grupp9.dsvkurs.miun.se/api/Movie/tt1160419');
    console.log(request.json())
    const url = request.url;
    const method = request.method;
    fetch(request)
    .then(response => {
      if (response.status === 200) {
        return response.json();
      } else {
        throw new Error('Something went wrong on api server!');
      }
    })
    .then(response => {
      console.debug(response);
      // ...
    }).catch(error => {
      console.error(error);
    });
  }

  // Expand more/less
  document.addEventListener('DOMContentLoaded', () => {
    const expandsMore = document.querySelectorAll('[expand-more]')

    function expand() {
      const showContent = document.getElementById(this.dataset.target)
      if(showContent.classList.contains('expand-active')) {
        this.innerHTML=this.dataset.showtext
      } else {
        this.innerHTML=this.dataset.hidetext
      }
      showContent.classList.toggle('expand-active')
    }

    expandsMore.forEach(expandMore => {
      expandMore.addEventListener('click', expand)
    })
  })
  
  function sendLike() {
        alert("Hello! I am an alert box!!");
    }
    
document.getElementById("likebutton0").addEventListener("click", sendLike)


