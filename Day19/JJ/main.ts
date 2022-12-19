// let input = await Deno.readTextFile("input.txt", "utf-8");
let input = await Deno.readTextFile("testInput.txt", "utf-8");

type Blueprint = {
  id: number;
  Robots: [
    type: string,
    cost: {
      clay: number;
      ore: number;
      obs: number;
    }
  ];
};

let regex =
  /Blueprint (\d+): Each ore robot costs (\d+) ore. Each clay robot costs (\d+) ore. Each obsidian robot costs (\d+) ore and (\d+) clay. Each geode robot costs (\d+) ore and (\d+) obsidian./;
let blueprints: Blueprint[] = [];

input.split("\n").map((line) => {
  let groups = regex.exec(line)!;
  blueprints.push({
    id: +groups[1],
    Robots: [
      {
        type: "ore",
        cost: {
          clay: 0,
          ore: +groups[2],
          obs: 0,
        },
      },
      {
        type: "clay",
        cost: {
          clay: 0,
          ore: +groups[3],
          obs: 0,
        },
      },
      {
        type: "obsidian",
        cost: {
          clay: +groups[5],
          ore: +groups[4],
          obs: 0,
        },
      },
      {
        type: "geode",
        cost: {
          clay: +groups[6],
          ore: 0,
          obs: +groups[7],
        },
      },
    ],
  });
});

let max = 0;
blueprints.map((bp) => {
  // console.log(bp.Robots[0].type);

  let oreBot = bp.Robots.filter((r) => r.type === "ore")[0];
  let clayBot = bp.Robots.filter((r) => r.type === "clay")[0];
  let obsBot = bp.Robots.filter((r) => r.type === "obsidian")[0];
  let geodeBot = bp.Robots.filter((r) => r.type === "geode")[0];

  let oreCost = oreBot.cost;
  let clayCost = clayBot.cost;
  let obsCost = obsBot.cost;
  let geodeCost = geodeBot.cost;
  // console.log(oreCost);
  // console.log(clayCost);
  // console.log(obsCost);
  // console.log(geodeCost);

  let maxOreCost = Math.max(
    ...[oreCost.ore, clayCost.ore, obsCost.ore, geodeCost.ore]
  );

  // console.log("MAX " + maxOreCost);
  let maxGeodes = 0;

  for (let tries = 0; tries < 10000; tries++) {
    let clay = 0,
      ore = 0,
      obs = 0,
      geode = 0;
    let bots = {
      ore: 1,
      clay: 0,
      obs: 0,
      geode: 0,
    };

    for (let i = 0; i < 24; i++) {
      // console.log("minute " + (i + 1));

      // console.log(ore);
      // console.log(clay);
      // console.log(obs);
      // console.log(geode);

      if (ore >= geodeCost.ore && obs >= geodeCost.obs) {
        // console.log("build a geodebot");
        bots.geode++;
        geode--;
        ore -= geodeCost.ore;
        obs -= geodeCost.obs;
      }
      if (
        Math.random() < 0.5 &&
        bots.obs < geodeCost.obs &&
        ore >= obsCost.ore &&
        clay >= obsCost.clay
      ) {
        // console.log("build an obs bot");
        bots.obs++;
        obs--;
        ore -= obsCost.ore;
        clay -= obsCost.clay;
      }
      if (
        Math.random() < 0.5 &&
        bots.clay < obsCost.clay &&
        ore >= clayCost.ore
      ) {
        // console.log("build a clay bot");
        bots.clay++;
        clay--;
        ore -= clayCost.ore;
      }
      if (Math.random() < 0.5 && bots.ore < maxOreCost && ore >= oreCost.ore) {
        // console.log("build an ore bot");
        bots.ore++;
        ore--;
        ore -= oreCost.ore;
      }

      ore += bots.ore;
      clay += bots.clay;
      obs += bots.obs;
      geode += bots.geode;

      // console.log(ore);
      // console.log(clay);
      // console.log(obs);
      // console.log(geode);
    }
    // console.log(geode);
    if (geode > maxGeodes) {
      console.log("mmmm");
      console.log(bots);
      console.log(ore);
      console.log(clay);
      console.log(obs);
      console.log(geode);
      maxGeodes = geode;
    }
  }
  console.log("max g " + maxGeodes);
  // console.log(maxGeodes * bp.id);
  max += maxGeodes * bp.id;
});
console.log(max);
