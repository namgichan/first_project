-- CREATE DATABASE projectDB;
USE projectDB;
DROP TABLE IF EXISTS userTBL, newsTBL, replyTBL;
CREATE TABLE userTBL
( userID varchar(20) NOT NULL PRIMARY KEY,
  userPW varchar(20) NOT NULL,
  userName varchar(5) NOT NULL,
  userPhone varchar(15) NULL,
  userEmail varchar(30) NULL,
  userAddr varchar(30) NULL
);
CREATE TABLE newsTBL
( newsNum int AUTO_INCREMENT NOT NULL PRIMARY KEY,
  newsArea char(3) NOT NULL,
  newsTitle varchar(100) NOT NULL,
  newsCont varchar(500) NOT NULL,
  newsPreDate DATETIME DEFAULT NOW() NOT NULL,
  Hits int default 0 NULL,
  userID varchar(20) NOT NULL,
  FOREIGN KEY(userID) REFERENCES userTBL(userID) ON UPDATE CASCADE
);
CREATE TABLE replyTBL
( replyNum int AUTO_INCREMENT NOT NULL PRIMARY KEY,
  Contents varchar(100) NOT NULL,
  replyPreDate DATETIME NOT NULL,
  userID varchar(20) NOT NULL,
  newsNum int NOT NULL,
  FOREIGN KEY(userID) REFERENCES userTBL(userID) ON UPDATE CASCADE,
  FOREIGN KEY(newsNum) REFERENCES newsTBL(newsNum)
);

INSERT INTO userTBL VALUES ('administrator', '1234', '운영자', NULL, NULL, NULL);
INSERT INTO newsTBL VALUES (NULL, '서울', '조폭도 MZ로 ''세대교체''…검거 조폭 58%가 10∼30대',
'이른바 ''MZ 조폭''으로 불리는 10∼30대 연령의 조직폭력배가 세를 불리는 것으로 나타났다. 경찰청 국가수사본부(국수본)는 
3월13일부터 이달 12일까지 넉 달간 조직폭력 범죄 특별단속에서 1천589명을 검거하고 313명을 구속했다고 26일 밝혔다.\n
https://www.yna.co.kr/view/AKR20230726066800004',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '서울', '서울 한복판 공원서 강간…피해자 생명 위독·피의자 검거',
'대낮 서울 한복판 공원 내 등산로에서 성폭행을 저지른 30대 남성이 경찰 조사 과정에서 강간 상해 혐의를 모두 인정하고 범행 동기와 수법, 
장소 등을 자백했다. 경찰은 이 남성에 대해 구속영장을 신청하고 구체적인 범행 경위 등에 대해 조사할 예정이다.\n
https://www.sedaily.com/NewsView/29TGFDY8SO/GK0104?utm_source=dable',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '서울', '서울 도심서 칼 들고 배회한 60대 남성 검거',
'흉기를 들고 서울 도심을 돌아다닌 60대 남성이 경찰에 붙잡혔습니다. 서울 혜화경찰서는 어젯(17일)밤 9시 25분쯤 성균관대 인근 골목에서 
"칼을 든 남성이 울듯이 괴성을 지르고 있다"는 신고를 받고 출동해 60대 남성 A씨를 검거했습니다.\n
https://yonhapnewstv.co.kr/news/MYH20230818007300641',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '서울', '"5명 죽일 것"...서울경찰청, 온라인 살인 예고글 작성자 5명 검거',
'서울경찰청은 5일 서울 각지에서 살인 범죄를 저지르겠다는 내용의 온라인 게시물을 쓴 작성한 혐의(협박 등)를 받는 5명을 검거했다고 밝혔다.\n
https://www.chosun.com/national/national_general/2023/08/05/SAEP6GBV3BCWLGXA3CPGPMODEQ/',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '서울', '용산 추락사 경찰관 연루 ‘마약 파티’ 추가 참석자 확인',
'''집단 마약 파티''가 이뤄지던 서울 용산구의 한 아파트에서 경찰관이 추락사한 사건을 수사 중인 경찰이 모임 참석자 3명에게 구속영장을 신청했다. 
경찰은 사건 현장에 있던 모임 참석자 5명을 추가로 파악해 마약 투약 여부 등을 확인하고 있다. 이 모임 참석자는 16명에서 21명으로 늘었다.\n
https://www.seoul.co.kr/news/newsView.php?id=20230907500255',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '강원도', '공무원 폭행 60대 민원인 징역형',
'원주시청 공무원 폭행혐의(본지 7월 28일자 온라인, 26일자 5면 보도)로 재판에 넘겨진 60대 민원인이 징역형을 선고받았다. A씨는 지난 7월 17일 
오전 6시 53분쯤 원주시청 당직실 안내데스크에 찾아가 ''재난 지원금을 달라''며 공무원에게 팸플릿을 던지고 가림막을 파손한 혐의로 재판에 넘겨졌다.\n
https://www.kado.net/news/articleView.html?idxno=1202749',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '강원도', '또래 여중생 집단폭행하고 영상 유포…강원도교육청·경찰 조사 착수',
'이틀간 노래방·골목·집서 폭행 후 영상 촬영, 피해 학생, 진정서 제출, 26일 강원특별자치도교육청과 경찰 등에 따르면 지난 22일 강원도 
내 한 노래방에서 중학생 3명이 A양을 폭행하는 장면이 찍힌 영상이 유포됐다.\n
https://www.kado.net/news/articleView.html?idxno=1195730',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '강원도', '''겁없는 10대''..외박나온 최전방 군인 집단폭행',
'강원 양구에서 고교생들이 외박 나온 현역 군인들을 집단 폭행한 사건이 발생했다.
강원 양구경찰서는 10일 외박 나온 현역 군인들을 집단 폭행한 혐의(폭력행위 등 처벌에 관한 법률 위반)로 김모(18)군과 또다른 김모(17)군 등 고교생 
10명을 불구속 입건했다.\n
https://www.yna.co.kr/view/MYH20110310005100038',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '강원도', '"관심 끌고 싶어서..." 원주역 칼부림 SNS에 올린 10대 검거',
'강원경찰청 사이버수사대는 ‘원주역 살인 예고’ 글을 사회관계망서비스(SNS)에 올린 혐의(협박)로 ㄱ(17)군을 붙잡아 조사하고 있다고 6일 밝혔다.\n
https://www.hani.co.kr/arti/area/gangwon/1103144.html',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '강원도', '부산서 연인 살해 후 도주한 30대...강원도 모텔서 검거',
'15일 부산 사상경찰서에 따르면 이번에 검거된 A씨는 지난 11일 새벽 부산 사상구 한 모텔에서 1년가량 교제한 40대 여자친구를 목 졸라 살해한 뒤 도주했다. 
A씨는 범행 다음 날인 지난 12일 오후 8시께 강원도에 있는 한 모텔에서 경찰에 검거된 것으로 알려졌다.\n
https://www.yna.co.kr/view/AKR20230515025500051',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '충청도', '잇단 은행, 환전소 털이…모방범죄 이어질까 우려',
'8월 18일 대전 서구의 한 신협에서 40대 남성 A씨가 현금을 훔쳐 베트남으로 출국하는 사건 발생. 
소화기 분말을 뿌려 직원 위협 후 현금 3900만원 훔친 뒤 미리 준비된 오토바이로 도주\n
https://www.cctoday.co.kr/news/articleView.html?idxno=2184101',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '충청도', '기름 냄새도 못 맡은 도둑들…''송유관 닿는 순간 잡혀'' 징역형',
'1월 말부터 3월 5일까지 청주시 국도 17번 인들을 지나는 송유관 근처까지 땅굴을 파 기름을 훔치려 한 일당 8명 징역형 선고\n
https://www.seoul.co.kr/news/newsView.php?id=20230908500147&wlog_tag3=naver',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '충청도', '여제자 성폭행 후 cctv 삭제한 대학 교수…”모든 게 물거품” 선처 호소',
'12월 12일 새벽 A씨의 집에서 술을 마시다 취해 잠든 20대 여제자와 여교수 B씨를 간음하거나 추행한 혐의로 재판에 넘겨 졌다.\n 
https://www.inews24.com/view/1630468',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '충청도', '가발쓰고 여탕 들어가 탈의실 영상찍은 30대…“호기심 때문에"',
'여성처럼 위장한 후 대중 목욕탕 여자 탈의실에 들어가 몰래 동영상 촬영을 하던 30대 남성이 경찰에 붙잡혔다.\n
https://www.cctoday.co.kr/news/articleView.html?idxno=2184101',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '충청도', '북 청주 음식점에서 칼부림...회사 직원, 미리 준비해온 흉기로 대표 찔러',
'6월 22일 오후 7시 24분 청주시 흥덕구 강서동 소재 음식점 내부에서 회사 직원 A 씨가 미리 준비해 온 흉기로 회사 대표 B 씨의 복부, 
목 등에 상해를 입혔다.\n
https://www.wikitree.co.kr/articles/863943',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경상도', '교도소 동기로 연결된 해외 마약상…한국서 밀반입 일당 적발',
'23.04월경 62만 명이 투약할 수 있는 양의 마약을 국내에 들여오려던 일당이 붙잡혔습니다. 
나이지리아와 캄보디아, 중국 등에 있는 마약상들과 정보를 공유하면서, 서로 마약을 나눠 쓴 걸로 확인됐습니다.\n
https://news.sbs.co.kr/news/endPage.do?news_id=N1007341711&plink=ORI&cooper=NAVER ',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경상도', '車7대 잇따라 ''쾅쾅쾅''만취운전 60대男검거',
'23.09.04 A씨는 전날 오전 10시 20분께 서구 비산동 주택가 골목에서 만취(0.166) 상태로 운전하다 주차된 차 7대의 
측면과 사이드미러 등을 파손한 혐의를 받는다.\n
https://www.idaegu.co.kr/news/articleView.html?idxno=432644',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경상도', '검은 헬멧쓰고 흉기 위협 “빚 때문에”…칠곡 새마을금고 강도 영장 신청 예정',
'23년 8월 31일 경북 칠곡의 한 새마을 금고를 흉기로 위협해 2천 30만원을 뺏고
금고에서 30미터쯤 떨어진 곳에 세워둔 자신의 차를 타고 달아났지만 멀리 가지 못하고
범행 3시간 40분 만에 경찰에 잡혔습니다.\n
https://dgmbc.com/article/7K888mgkGoRj18gre',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경상도', '알바 면접 미끼 성폭행, 피해 재수생 사망…30대''가짜 사장 구속''',
'23년 4월경 ㄴ씨는 ㄱ양에게 스터디 카페 사장이라고 속이고 면접을 보겠다며 부산진구의 한 스터디 카페로 오라고 했다. 
면접하는 척하던 ㄴ씨는 “더 쉽게 좋은 일이 있다”며 ㄱ양을 근처 성매매업소로 데리고 가 성폭행을 저질렀다.
 ㄱ양은 범행을 당한 뒤 심리적 충격으로 어려워하다 얼마 뒤 스스로 목숨을 끊었다.\n
https://www.hani.co.kr/arti/area/yeongnam/1107447.html',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경상도', '부산 교차로서 ''쾅쾅쾅쾅''4중 충돌…사고 운전자는 무면허',
'23년 9월 7일 부산 동구의 한 교차로에서 A(10대)군이 몰던 승용차가 4중 추돌 사고를 일으켜 9명이 크게 다쳤다.\n
https://www.mk.co.kr/news/society/10825526',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경기도', '차로 들이받은 뒤 무차별 칼부림…분당 서현역서 14명 부상',
'8월 3일 오후 5시59분쯤 피의자는 모닝 차량을 몰아 서현역 역사 앞 인도로 돌진해 지나가던 행인 여러 명을 친 다음, 
차에서 내린 뒤 AK플라자로 이동해 1, 2층을 돌아다니며 흉기를 휘두른 것으로 파악됐다 현재까지 확인된 피해자는 모두 14명으로, 이중 12명이 중상을 입었다.\n  
https://www.chosun.com/national/national_general/2023/08/03/C4WPYO7JRRA73BHEF6NFKJM7CU',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경기도', '''성폭행하려고'' 엘베 무차별 폭행…피해자가 영상공개',
'지난 7월 경기도 의왕시 한 아파트 엘리베이터에서 
20대 남성이 성폭행을 목적으로 이웃 여성을 무차별 폭행한 사건과 관련해 피해자가 가해자의 엄벌을 촉구하며 당시 상황이 담긴 영상을 공개하고 나섰다.\n  
https://news.kmib.co.kr/article/view.asp?arcid=0018626958&code=61121211&cp=nv',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경기도', '버스 기사 폭행한 대학교수…”술 취해 기억 안나”',
'23.07.13에 운행 중인 버스 안에서 기사를 폭행한 대학교수가 검찰에 넘겨졌다. 폭행 당시 교수는 만취 상태였던 것으로 알려졌다.\n
https://news.mt.co.kr/mtview.php?no=2023072514291696677',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경기도', '이주노동자 집단 폭행한 10대들…외면 당한 구조 요청',
'23년 7월경 포천시에서 10대 청소년 네 명이 이주 노동자를 집단 폭행한 일이 발생했습니다.경찰 출동 뒤에야 폭행은 멈췄는데, 
이주 노동자는 막무가내 폭행을 당하고도 오히려 쫓겨날 위기에 처하게 됐습니다.\n
https://news.kbs.co.kr/news/view.do?ncd=7718450&ref=A',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '경기도', '“한번 때려줘?”… ‘너클’ 끼고 보행자 폭행한 10대 운전자 실형',
'A씨는 지난 1월 7일 오전 2시20분쯤 경기도 수원시 팔달구 한 도로에서 차량을 후진하다 아내와 함께 걷고 있던 보행자 B씨를 쳤다. 
이에 B씨가 항의하자 오른손에 너클을 착용한 채 차에서 내려 B씨의 왼쪽 눈 부위를 한차례 때린 혐의로 기소됐다.\n
당시 B씨는 안경을 끼고 있어 눈 아래를 크게 다친 것으로 알려졌다.  
https://news.kmib.co.kr/article/view.asp?arcid=0018308628&code=61121111&cp=nv',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '제주도', '제주도 찰 돌며 시줏돈 슬쩍 20대 구속',
'A씨는 지난 8월 16일부터 21일까지 서귀포시 안덕면과 제주시 구좌읍 사찰 5곳을 돌며 시줏돈 22만원을 훔친 혐의를 받고있다.\n
https://www.siminilbo.co.kr/news/newsview.php?ncode=1160285687689273',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '제주도', '제주도에서 끔찍한 흉기 사건 발생… 피해자가 11세 여동생이다',
'4월 14일 제주 서부 경찰서에 따르면 이날 오전 4시 40분꼐 제주 외도동 소재 주택에서 A(20)씨가 여동생B양(11)에게 흉기를 휘두르고 달아났다는 신고가 접수됐다.\n
https://www.wikitree.co.kr/articles/845519',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '제주도', '말투 맘에 안든다며 처음 보는 남성 둔기로 폭행한 제주도 서핑 강사',
'23년 8월 18일 애월읍 한 편의점 인근 도로에서 40대 서핑 강사 A씨가 20대 주민 B씨랑 실랑이를
벌이다 둔기로 폭행하는 사건이 일어났다. A씨는 몸싸움을 벌이다 B씨를 둔기로 쓰러뜨리고 B씨가 쓰러진 상태에도 무차별 폭행을 가하였다.\n
https://www.insight.co.kr/news/448152',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '제주도', '제주도에서 벌어진 무서운 살인 사건…부검 결과가 정말 끔찍하다',
'A씨는 22년 12월 16일 오후 3시쯤 제주시 오라동 한 빌라에서 유명 음식점 대표인 50대 여성 D씨를 둔기로 살해한 혐의를 받는다. 
A씨는 피해자의 귀가를 기다린 뒤 둔기로 머리와 목을 여러 차례 때린 것으로 알려졌다.\n
https://www.wikitree.co.kr/articles/816861',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '제주도', '택시비 뺏으려 미성년자 강도·강간 제주 40대, 살인예비 혐의 부인',
'23년 5월 김씨는 제주도내 한 생활형 숙박시설에서 미성년자인 피해자를 몰래 뒤쫒아가 흉기로 위협, 피해자 거주지에 침입한 혐의다. 
김씨는 겁을 먹은 피해자에게 돈을 뺏으려 하고, 피해자를 강간한 혐의를 받는다.\n
https://www.jejusori.net/news/articleView.html?idxno=417120',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '전라도', '광주지방경찰청 이상 동기 범죄 예고 글 작성자 검거',
'광주지방경찰청 사이버범죄수사대는 02:28경 ‘칼부림하겠다는 글을 봤다’는 112문자 신고내용을 확인하고 즉시 조사를 착수하였으며, 
피의자의 소셜 계정을 확인, 추적하여 피의자의 인적 사항을 특정하고 08:48경 광주 서구 인근에서 피의자를 검거하였다.\n
https://www.jeollailbo.com/news/articleView.html?idxno=7019032.',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '전라도', '전라도 7개 시군 돌며 전원주택 상습 절도 40대 검거',
'전라도 일대 야산을 끼고 있는 주택단지를 노려 귀금속과 현금 등 수천만 원을 훔친 혐의로 40대 남성이 경찰에 붙잡혔습니다. 전남 장성경찰서는 
상습절도 혐의로 46살 심 모 씨를 붙잡아 조사하고 있습니다.\n
https://news.kbs.co.kr/news/view.do?ncd=7601598',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '전라도', '"내가 왜 인사해?"... 술집서 패싸움 한 폭력조직원 21명 ''입건''',
'전주의 한 번화가 술집서 패싸움을 벌인 폭력조직원들이 무더기로 경찰에 붙잡혔다.
전북경찰청 강력범죄수사대는 폭력 행위 등 처벌에 관한 법률 위반(공동폭행) 등 혐의로 A씨(20대) 등 21명을 입건해 조사 중이라고 13일 밝혔다.\n
https://www.jeollailbo.com/news/articleView.html?idxno=698641',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '전라도', '운전 속도 늦다며 노인 폭행한 10대 입건',
'익산경찰서는 70대 노인을 폭행한 혐의로 A(17)군을 불구속 입건했다고 2일 밝혔다.
경찰에 따르면 A군은 지난달 28일 오후 6시께 익산시 평화동의 한 사거리에서 오토바이 운전자 B(71)씨를 밀어 넘어뜨리고 주먹으로 수차례 폭행한 혐의를 
받고 있다.\n
http://www.jlmaeil.com/default/index_view_page.php?idx=162592&part_idx=180',
'2023-09-11 11:50:00', 0, 'administrator');
INSERT INTO newsTBL VALUES (NULL, '전라도', '''상습 무전취식''한 전주지검 군산지청 검찰 수사관 입건',
'전주완산경찰서는 27일 전주시내 음식점을 돌며 무전 취식을 한 혐의(사기)로 검찰 수사관 A씨(48)를 불구속 입건했다고 밝혔다. 전주지검 군산지청 소속 수사관인 A씨는 
지난 19일부터 25일 사이 전주시 완산구 일대를 돌아다니며 세 차례에 걸쳐 수십 만 원 상당의 음식값을 내지 않은 것으로 드러났다.\n
https://www.jjan.kr/article/20230627580252',
'2023-09-11 11:50:00', 0, 'administrator');
