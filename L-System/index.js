/*
  # Demo code for L-systems
*/


// ## An L-System needs...
// variables, constants (alphabet)
// rules (production rules)
// a way to expand a string through iteration
// way to interpret string into visual 

// ## The dragon curve drawn using an L-system.
// variables : F G
// constants : + −
// start  : F
// rules  : (F → F+G), (G → F-G)
// angle  : 90°
let alphabet = ['F', 'G', '+', '-', 'X', 'T'];
const axiom = 'F';
const rules = {
  'F': 'F+G-X',
  'G': 'F-G+T',
  '-': '-',
  '+': '+',
  'X': 'X-X',
  'T': 'T+T'
};

const iterate_once = (lindenmayerString) => {
  let newString = '';
  for (let i = 0; i < lindenmayerString.length; i++) {
    const result = rules[lindenmayerString[i]];
    newString += result || lindenmayerString[i];
  }
  return newString;
}

const iterateNTimes = (n, lindenmayerString) => {
  let newString = lindenmayerString;
  for (let i = 0; i < n; i++) {
    newString = iterate_once(newString);
  }
  return newString;
};

const makeVisual = (options, lindenmayerString) => {
  let theSvgString = '';
  
  // Basically constants
  let angle = (options.angle || 90) * Math.PI / 180;
  let startingPoint = options.startingPoint || [0, 0];
  let lineLength = options.lineLength || 10;

  // State
  let rotation = 0;
  let points = [startingPoint];

  const moveForward = () => {
    const lastPoint = points[points.length - 1];

    const dx = Math.cos(rotation) * lineLength;
    const dy = Math.sin(rotation) * lineLength;

    points.push([lastPoint[0] + dx, lastPoint[1] + dy]);
  };

  const whatToDo = {
    'F': () => {
      return moveForward();
    },
    'G': () => {
      return moveForward();
    },
    '+': () => {
      angle = Math.random() * -90;
    },
    '-': () => {
      angle = Math.random() * 90;
    },
    'X': () => {
      rotation = rotation - angle;
    },
    'T': () => {
      rotation = rotation + angle;
    }
  };

  for (let i = 0; i < lindenmayerString.length; i++) {
    const toDo = whatToDo[lindenmayerString[i]];
    toDo();
  }

  for (let i = 0; i < points.length - 1; i++) {
    theSvgString += `<line x1="${points[i][0]}" y1="${points[i][1]}" 
                           x2="${points[i + 1][0]}" y2="${points[i + 1][1]}" 
                           style="stroke:rgb(${i%255},0,0);stroke-width:.2" />`;
  }

  return theSvgString;
  // // return a path moving through all the points
  // return `<polyline points="${points.join(' ')}" 
  //                   fill="none" stroke="black" 
  //                   stroke-width=".2px"/>`;
  
};

const expanded = iterateNTimes(15, axiom);

const result = makeVisual({
  lineLength: 1.5,
  angle: 90,
  startingPoint: [50, 0]
}, expanded);

// get result into the svg in the dom
const svg = document.querySelector('svg');
svg.innerHTML = result;

// let oneStep = iterate_once(axiom);
// debugger;