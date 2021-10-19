function login() {
  let email = document.getElementById("email").value;
  let password = document.getElementById("password").value;

  console.log("started");

  let url = "http://localhost:49158/Authentication/login";

  let req = fetch(url, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ Email: email, Password: password }),
  });

  req.then((data) => {
    console.log(data.json());
  });
}
