let input = Deno.readTextFileSync("input.txt", "utf-8");
// let input = Deno.readTextFileSync("testInput.txt", "utf-8");

input = input.split("\n");

let operations: {
  name: string;
  op: string;
  left: string | number;
  right: string | number;
  terms: number;
} = [];

function solve(humn: number) {
  const numbers = new Map<string, number>();
  numbers.set("humn", humn);
  input.map((line) => {
    let s = line.split(": ");
    let name = s[0];
    if (Number.isInteger(+s[1])) {
      numbers.set(name, +s[1]);
    } else {
      let operation = s[1].split(" ");
      let left = Number.isInteger(+operation[0]) ? +operation[0] : operation[0];
      let right = Number.isInteger(+operation[2])
        ? +operation[2]
        : operation[2];
      let terms = 0;
      if (typeof left === "string") terms++;
      if (typeof right === "string") terms++;
      operations.push({
        name,
        op: operation[1],
        left,
        right,
        terms,
      });
    }
  });

  let stackOp = [];
  while (operations.length > 0) {
    let toRemove: string[] = [];
    operations.map((operation) => {
      // console.log(operation);
      if (operation.left === "humn" || operation.right === "humn") {
        stackOp.push(operation);
        console.log(stackOp);
      }
      if (numbers.has(operation.left)) {
        //   console.log(numbers.get(operation.left));
        operation.left = numbers.get(operation.left);
        operation.terms--;
      }
      if (numbers.has(operation.right)) {
        operation.right = numbers.get(operation.right);
        operation.terms--;
      }
      if (operation.terms === 0) {
        // console.log(`(${operation.left})${operation.op}(${operation.right})`);
        numbers.set(
          operation.name,
          eval(`(${operation.left})${operation.op}(${operation.right})`)
        );
        toRemove.push(operation.name);
      }
    });
    // if (numbers.get("cwtl")) break;
    operations = operations.filter((item) => !toRemove.includes(item.name));
  }

  //   return { a: numbers.get("cwtl"), b: numbers.get("wqpn") };
  return { a: numbers.get("pppw"), b: numbers.get("sjmn") };
}

let count = 0;
while (true) {
  let { a, b } = solve(++count);
  if (count % 1000 === 0) console.log(count);
  if (a === b) {
    console.log(count);
    break;
  }
}
// console.log(operations);
