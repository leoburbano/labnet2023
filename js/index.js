let numero = Math.floor(Math.random() * 20) + 1;
let intentos = 0;
let puntos = JSON.parse(localStorage.getItem("puntaje"));
let puntuacionMasAlta = `${puntos.puntajeJ}`;
let oportunidades = 9;

function resetGame() {
  document.getElementById("numero").value = "";
  getPuntaje();
  intentos = 0;
  document.getElementById("pista").value = "";
  numero;
}

function checkNumber() {
  if (intentos != oportunidades) {
    let playerNumber = parseInt(document.getElementById("numero").value);
    intentos++;
    if (playerNumber == numero) {
      if (
        20 - intentos > puntuacionMasAlta ||
        puntuacionMasAlta === undefined
      ) {
        const urlWin =
          "https://videohive.img.customer.envatousercontent.com/files/6220d5f3-ed15-472a-a9b9-7191c52cda6f/inline_image_preview.jpg?auto=compress%2Cformat&fit=crop&crop=top&max-h=8000&max-w=590&s=629e05df89a6408e6847a64bc33ce5c3";

        let div = document.getElementById("cuerpo");
        div.style.backgroundImage = `url(${urlWin})`;
        let jugador = prompt("Ingresa tu nombre");
        puntuacionMasAlta = { nombre: jugador, puntajeJ: 20 - intentos };
        localStorage["puntaje"] = JSON.stringify(puntuacionMasAlta);
        resetGame();
      } else {
        const urlWin =
          "https://videohive.img.customer.envatousercontent.com/files/6220d5f3-ed15-472a-a9b9-7191c52cda6f/inline_image_preview.jpg?auto=compress%2Cformat&fit=crop&crop=top&max-h=8000&max-w=590&s=629e05df89a6408e6847a64bc33ce5c3";

        let div = document.getElementById("cuerpo");
        div.style.backgroundImage = `url(${urlWin})`;
      }
    } else if (playerNumber > numero) {
      document.getElementById("pista").innerHTML = `
      <b>Pista: </b>El número es MENOR que ${playerNumber}
    `;
      document.getElementById("numero").value = "";
      document.getElementById("intentos").innerHTML = `
      <b>Te quedan:</b> ${oportunidades - intentos} intentos
    `;
    } else if (playerNumber < numero) {
      document.getElementById("pista").innerHTML = `
      <b>Pista: </b> El número es MAYOR que ${playerNumber}
    `;
      document.getElementById("numero").value = "";
      document.getElementById("intentos").innerHTML = `
      <b>Te quedan:</b> ${oportunidades - intentos} intentos
    `;
    }
  } else {
    const urlLoose =
      "https://media.istockphoto.com/id/1368072565/es/vector/pixel-game-over-pixel-game-over-de-8-bits.jpg?s=612x612&w=0&k=20&c=ltfB6wyND0ygWVtpeqHCX53M8lxAAooj0YLS8joHNdY=";

    let div = document.getElementById("cuerpo");
    div.style.backgroundImage = `url(${urlLoose})`;

    resetGame();
  }
}

function getPuntaje() {
  let score = JSON.parse(localStorage.getItem("puntaje"));

  document.getElementById("puntuacion").innerHTML = `
    <b>HighScore: ${score.nombre} : ${score.puntajeJ}</b>
    `;
}
