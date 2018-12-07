var currentQuestion = 0;
var score = 0;
var totQuestions = questions.length;

var container = document.getElementById('quizContainer');
var questionEl = document.getElementById('question');
var opt1 = document.getElementById('opt1');
var opt2 = document.getElementById('opt2');
var opt3 = document.getElementById('opt3');
var opt4 = document.getElementById('opt4');
var nextButton = document.getElementById('nextButton');
var backButton = document.getElementById('backButton');
var resultCont = document.getElementById('result');

function loadQuestion (questionIndex) {
	var q = questions[questionIndex];
	questionEl.textContent = (questionIndex + 1) + '. ' + q.question;
	opt1.textContent = q.option1;
	opt2.textContent = q.option2;
	opt3.textContent = q.option3;
    opt4.textContent = q.option4;
    //if (!questions[currentQuestion].answer) {
       
    //}

};
function loadPrevQuestion() {

    currentQuestion = currentQuestion - 1;
    loadQuestion(currentQuestion);
}

function loadNextQuestion () {
	var selectedOption = document.querySelector('input[type=radio]:checked');
	if(!selectedOption){
		alert('Please select your answer!');
		return;
	}
	var answer = selectedOption.value;
	//if(questions[currentQuestion].answer == answer){
	//	score += 10;
 //   }
    selectedOption.checked = false;
    //adult or kids
    if (questions[currentQuestion].answer1 == answer) {       //adult           
        currentQuestion = currentQuestion + 2;        //open road ,dirt trails,cities 
        if (questions[currentQuestion].answer2 == answer) {
            currentQuestion = currentQuestion + 3;     //sport fitness,peformance road racing and triathon     
            if (questions[currentQuestion].answer2 == answer) {
                currentQuestion = currentQuestion + 3;      

            }

        }

    }
    if (questions[currentQuestion].answer2 == answer) {  //kids
        currentQuestion = currentQuestion + 1;
        if (questions[currentQuestion].answer1 == answer ) {
            currentQuestion = currentQuestion + 3;

        }

    }

    //open road ,dirt trails,cities  >< ages 2-4,4-6,6-8

	//if(currentQuestion == totQuestions - 1){
	//	nextButton.textContent = 'Finish';
	//}
	if(currentQuestion == totQuestions){
		container.style.display = 'none';
		resultCont.style.display = '';
		resultCont.textContent = 'Your Score: ' + score;
		return;
	}
	loadQuestion(currentQuestion);
}

loadQuestion(currentQuestion);