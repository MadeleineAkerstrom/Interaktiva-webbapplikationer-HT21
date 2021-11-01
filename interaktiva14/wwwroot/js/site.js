// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function readMoreFunction(id) {
    var dots = document.getElementById("dots_" + id);
    var moreText = document.getElementById("more_" + id);
    var btnText = document.getElementById("myBtn_" + id);

    if (dots.style.display === "none") {
      dots.style.display = "inline";
      btnText.innerHTML = "Read more";
      moreText.style.display = "none";
    } else {
      dots.style.display = "none";
      btnText.innerHTML = "Read less";
      moreText.style.display = "inline";
    }
  }

  function likeFunction()
  {
    let test = document.getElementById("btn_1")
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

  function dislikeFunction()
  {

  }