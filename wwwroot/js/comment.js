const commentBtn = document.querySelector("#commentFrm");//이해 하기 쉽게 말하자면 html로 보내진 내용이 그대로 따라간다.  <form id="commentFrm" method="post"> 와 연결되있다. 
const commentList = document.querySelector("#comment-list"); //댓글리스트다. 계속출력하기위해 필요한 존재.
const total = document.querySelector("h4 > span"); //컨테이너 태그가 제목보다 튀어선 안된다. 
let list = []; // 배열 댓글리스트로 비어있기때문에 값을 계속집어넣을수있다.
//배열 선언및 초기화 

function Comment(content) { //기능 펑션 에다가 정적함수를 사용하여 인수 content 연결  
    this.userid = "익명";
    this.content = content; //얘를 가지고연결함 
    this.date = new Date().toLocaleString();  //바로 현재 시간 저장
}

function createRow(userid, content, date, index) { //테이블행 추가 
    const ul = document.createElement("ul"); // 
    const li1 = document.createElement("li");
    const li2 = document.createElement("li");
    const li3 = document.createElement("li");
    const li4 = document.createElement("li");

    ul.append(li1); //추가  ul.추가(li) 
    ul.append(li2);
    ul.append(li3);
    ul.append(li4);

    ul.setAttribute("class", "comment-row");
    li1.setAttribute("class", "comment-id"); //속성값 지정 
    li2.setAttribute("class", "comment-content");
    li3.setAttribute("class", "comment-date");
    li4.setAttribute("class", "comment-delete");

    li1.innerHTML = userid;
    li2.innerHTML = content;
    li3.innerHTML = date;
    li4.innerHTML = "삭제";

    li4.addEventListener("click", () => {
        deleteComment(index);
        totalRecord();
        drawing();
    });

    return ul;
}

function commentBtnHandler(e) {
    e.preventDefault();
    const input = e.target.content;
    if (input.value === "") {
        alert("내용을 넣고 등록 버튼을 눌러주세요.");
        return;
    }
    const commentObj = new Comment(input.value);
    const pageId = getPageId(); // 페이지의 id값을 가져옴
    const key = `comments_${pageId}`; // key값 생성
    const comments = JSON.parse(sessionStorage.getItem(key) || "[]"); // 해당 key로 저장된 댓글 데이터를 가져옴
    comments.push(commentObj); // 새로운 댓글 객체를 추가함
    sessionStorage.setItem(key, JSON.stringify(comments)); // 해당 key에 새로운 댓글 데이터를 저장함
    totalRecord();
    drawing();
    e.target.reset();
}

function drawing() {
    commentList.innerHTML = "";
    const pageId = getPageId(); // 페이지의 id값을 가져옴
    const key = `comments_${pageId}`; // key값 생성
    const comments = JSON.parse(sessionStorage.getItem(key) || "[]"); // 해당 key로 저장된 댓글 데이터를 가져옴
    list = [...comments];
    for (let i = list.length - 1; i >= 0; i--) {
        const row = createRow(list[i].userid, list[i].content, list[i].date, i);
        commentList.append(row);
    }
}

function totalRecord() {
    const pageId = getPageId(); // 페이지의 id값을 가져옴
    const key = `comments_${pageId}`; // key값 생성
    const comments = JSON.parse(sessionStorage.getItem(key) || "[]"); // 해당 key로 저장된 댓글 데이터를 가져옴
    list = [...comments];
    total.innerHTML = `(${list.length})`;
}

function deleteComment(index) {
    const pageId = getPageId(); // 페이지의 id값을 가져옴
    const key = `comments_${pageId}`; // key값 생성
    const comments = JSON.parse(sessionStorage.getItem(key) || "[]"); // 해당 key로 저장된 댓글 데이터를 가져옴
    comments.splice(index, 1); // 해당 index의 댓글 객체를 삭제함
    sessionStorage.setItem(key, JSON.stringify(comments)); // 해당 key에 변경된 댓글 데이터를 저장함
}

function getPageId() {
    const url = window.location.href; // 현재 페이지의 URL을 가져옴
    const urlArray = url.split("/"); // URL을 "/" 기준으로 나눔 이게있어야 crud/details/ 이렇게 나누라는뜻 
    return urlArray[urlArray.length - 1]; // 마지막 부분인 페이지의 id값을 반환함
}

commentBtn.addEventListener("submit", commentBtnHandler);
window.onload = () => {
    totalRecord();
    drawing();
}