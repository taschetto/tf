CREATE TABLE Category (
  id_category INTEGER PRIMARY KEY IDENTITY,
  name VARCHAR(200) NOT NULL,
  descript VARCHAR(200) NOT NULL
);

CREATE TABLE Exam (
  id_exam INTEGER PRIMARY KEY IDENTITY,
  questionCount INTEGER NOT NULL,
  [open] char(1) NOT NULL,
  accessCode VARCHAR(10)
);

CREATE TABLE CategoryExam (
  id_category INTEGER NOT NULL REFERENCES Category,
  id_exam INTEGER NOT NULL REFERENCES Exam,
  PRIMARY KEY (id_category, id_exam)
);


CREATE TABLE Question (
  id_question INTEGER PRIMARY KEY IDENTITY,
  questionContent VARCHAR(200) NOT NULL,
  feedbackContent VARCHAR(200) NOT NULL,
  rightAlternative INTEGER NOT NULL
);

CREATE TABLE Alternative (
  id_alternative INTEGER PRIMARY KEY IDENTITY,
  question INTEGER NOT NULL REFERENCES Question,
  answerContent VARCHAR(200) NOT NULL
);


CREATE TABLE CategoryQuestion (
  id_category INTEGER NOT NULL REFERENCES Category,
  id_question INTEGER NOT NULL REFERENCES Question,
  PRIMARY KEY (id_category, id_question)
);


CREATE TABLE Student (
  id_student INTEGER PRIMARY KEY IDENTITY,
  registration INTEGER NOT NULL,
  [password] VARCHAR(200) NOT NULL,
  name VARCHAR(200) NOT NULL,
  email VARCHAR(200) NOT NULL
);

CREATE TABLE StudentExam (
  id_student INTEGER NOT NULL REFERENCES Student,
  id_exam INTEGER NOT NULL REFERENCES Exam,
  PRIMARY KEY ("id_student", "id_exam")
);


CREATE TABLE Answer (
  id_question INTEGER NOT NULL REFERENCES Question,
  id_studentexam_student INTEGER NOT NULL,
  id_studentexam_exam INTEGER NOT NULL,
  id_alternative INTEGER REFERENCES Alternative,
  PRIMARY KEY (id_question, id_studentexam_student, id_studentexam_exam),
  FOREIGN KEY (id_studentexam_student, id_studentexam_exam) REFERENCES StudentExam (id_student, id_exam)
);
