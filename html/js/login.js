function login() {
  var email = document.getElementById("email").value;
  var password = document.getElementById("password").value;

console.log("started");

  var url = "http://localhost:49158/Authentication/login";

  var req = fetch(url, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({"Email": email, "Password": password})
  });

  req.then((data) => {
    console.log(data.json());
  })
}
