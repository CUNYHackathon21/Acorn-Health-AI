const brain = require("brain.js").brain;
const data = require("./Data.json");

function ai() {
  const network = new brain.recurrent.LSTM();

  const trainingData = data.map((item) => ({
    input: item.text,
    output: item.category,
  }));

  network.train(trainingData, {
    iterations: 2000,
  });

  let userPain = document.innerHTML("userPain").value;

  consol.log(userPain);

  const output = network.run("The code has some bugs");
  console.log(`Category: ${output}`);
}
