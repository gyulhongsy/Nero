using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> talkData;
    string[] talkerData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        talkerData = new string[500];

        GenerateData();
    }

    void GenerateData()
    {
        // Talk Data
        // 집 탭
        talkData.Add(100, new string[] { "아무도 없네, 밥 구하러 갔나?" });

        // 밥 탭
        talkData.Add(101, new string[] { "밥이 비어있어", "근데 이건 무슨 가루지?" });

        // 고양이 무리
        talkData.Add(110, new string[] { "누구신데 저희 집 앞에 계세요?", "(네로를 비웃으며) 지금 우리를 모르는 거임? 말도 안 됨. 금붕어가 더 똑똑하겠음.",
            "…모르겠는데요. 누구신데 저희 집에 멋대로 들어오시는 거예요?", "방금 모르겠다고 했다냥? 형님 저희 분발해야겠습니다냥! (영역 표시를 하며)",
            "아니 남의 집에서 뭐하시는거예요!", "어이구 알고싶냐, 꼬맹이? 근데 어쩌나 이제 우리 아지트인걸?",
            "네? 그게 무슨 소리예요!", "아까 가게 아줌마가 너네 부모님 다른 곳으로 옮겼음. 킥킥. 그것도 모른 거임? 정말 한심함.",
            "어디로요?", "모름. 우리가 그걸 어떻게 알겠음? 뭐 알아도 안 알려줄 거임.",
            "꼬맹아. 어쨌든 여기는 이제 우리 구역이니까 썩 꺼져라.", "싫어요!",
            "(한숨을 쉬며) 애기야, 좋은 말로 할 때 가라냥.", "싫어요! 여긴 제가 태어날 때부터 살던 집이에요!",
            "아 엄청 앵앵거리네. 야 가라고.", "(…부모님은 어디 가신 걸까? 마을을 둘러 보자)"
        });

        // 쓰레기 수거함
        talkData.Add(120, new string[] { "저런 못난 놈들. 에잉 쯧.", "나무 할아버지 안녕하세요.",
            "허허. 안녕하세요. 아기 고양이씨, 요새 이렇게 인사하는 아이들이 드문데 참 바른 아이구나.", "감사합니다. 할아버지….",
            "그런데 어째 무슨 일 있었느냐…? 얼굴 절반이 검네.", "그건 제 무늬에요. 할아버지.",
            "안다. 너 웃으라고 한 번 농을 해봤다. 표정을 보아하니 무슨일이 있던거니?", "저희 집을 언니 오빠들한테 빼앗겼어요.",
            "에휴... 또 그놈들이냐? 근데 너희 부모님은 집에 안 계셨니?", "네…. 아까 가게 아줌마가 저희 부모님을 다른 곳으로 옮기셨대요.",
            "어디인지는 모르고?", "네..(깊은 한숨이 나온다)",
            "(중얼중얼) 아까 그 아줌마인가.. 얘랑 똑같이 생긴 고양이 두 마리를 들고갔던 것 같은데..",
            "네? 아줌마 어디 가시는지 보셨어요?",
            "(난처한 표정을 지으며) 아, 다시 생각해보니 아줌마가 아닌 것 같구나.. (부모님이 끌려가신 걸 알면 애 마음이 찢어지겠지..)",
            "그렇군요... 저희 부모님은 어디 계신 걸까요?", "글쎄다. 아마 고양이별로 갔을 듯 싶구나",
            "고양이 별이요?", "그래.우리 고양이들 사이에는 신기한 소문이 하나 있지.\n저기 하늘 너머에, 고양이 별이라는 곳이 존재한다고 하더구나.",
            "정말요? 그런데 저희는 하늘까지 점프할 수 없잖아요?", 
            "그러게나 말이구나. 그렇지만 고양이 별로 갈 수 있는 특별한 통로가 있다더구나.",
            "통로요? 어디있는데요? 빨리 알려주세요, 할아버지!", "글쎄, 나도 어디있는지는 모르겠구나. 정말 미안하구나.",
            "(시무룩한 표정을 지으며) 아니에요 할아버지. 알려주셔서 감사합니다. 저는 얼른 고양이별을 찾아 가봐야겠어요.",
            "그러려무나. 조심히 가거라.", "건강히 잘 지내셔야 해요.",
            "아 네로야 가기전에 이 가방 하나 갖고 가렴. 도움이 될게야.", "감사합니다! 할아버지 저 다녀올게요. (고양이 별을 찾아 가야 해!)"
        });

        // 술 취한 아저씨
        talkData.Add(210, new string[] { "!@#$%^", "아저씨가 술에 취하셨네. 방금 자판기에서 뽑은 숙취해소제를 드려볼까?" });

        talkData.Add(211, new string[] { "아저씨! 정신이 드세요?", "귀여운 (딸꾹) 고양이네 (딸꾹)",
            "아저씨 여기서 자면 안 돼요!", "허… 녀석 말도 참 잘하네.",
            "뭐지? 아저씨 제 말을 어떻게 알아들어요?", "옛날에 너 같은 고양이 한마리가 있었는데 (딸꾹) 그 아이도 꼭 너처럼 말을 차암 잘 했지.",
            "아저씨 얼른 집에 들어가세요. 사람은 밖에서 자면 입 돌아간대요", "그 날, 그 고양이를 따라가다가 참 신기한 걸 봤는데 (딸꾹) 거기는 고양이들이 무척 많았어.",
            "뭐지 꿈 꾸시는 건가?", "너는 어디로 가는 중이니.", 
            "고양이 별이요. 아저씨는 어차피 모르겠지만요", "혹시 갈 데가 없으면 우리 집에서 살래? 회사에서 잘리고 이혼도 하고 인생이 참 쓸쓸하구나.",
            "…감사하지만 전 고양이별로 꼭 가야해요.", "별로인가 보구나. 그러면 그 고양이처럼 그 곳을 찾아가봐.\n웜홀… 반짝이는 통로였지…. 그 고양이를 따라 또 한 번 가보고 싶구나.",
            "웜홀?", "고양아, 이거 하나 갖고갈래? 맞다, 너 이름은 뭐니?",
            "전 네로예요!", "그래. 잘 가렴, 네로야.",
            "(꼭 부모님을 찾을게요. 아저씨도 잘 지내세요.)"
        });

        // 길 잃은 소녀
        talkData.Add(310, new string[] { "훌쩍…. 훌쩍." });
        talkData.Add(311, new string[] { "… 맛있다 고마워.", "근데 왜 여기서 울고 있어?",
        "… 나 엄마 아빠 잃어버렸어.", "어쩌다가?",
        "그냥 자판기가 반짝반짝해서… 신기해서 보고 있었는데 갑자기 엄마 아빠가 사라졌어.",
        "그랬구나. 나도 마찬가지인데..", "어, 우리 엄마 아빠다! 엄마! 아빠! 고양이야 음료수 고마웠어!",
        "그래. 잘 가! (나도 부모님을 다시 만나고 싶어…."
        });

        // 캣잎에 취한 고양이
        talkData.Add(410, new string[] {"냐옹~ 냐옹~", "(하~암)", "캣잎 내노라옹!",
        "@.@", "너도 캣잎 상점 갈거냥?", "…뭐냐옹 냐옹 냐옹…."
        });

        // 캣잎 상점 아줌마
        talkData.Add(420, new string[] { "(무관심하게 다른 곳을 쳐다보며) 너도 캣잎 살려고?", "아니요. 갑자기 땅이 푹 꺼져서 떨어졌더니 이곳에 오게 되었어요.",
        "근데 너… 되게 쓸데없는 걸 갖고 있네?", "아 이 조각난 구슬이요? 이 구슬에 대해 아시나요?",
        "글쎄. 넌 알 필요가 없을 것 같은데? 그 구슬 나 줄래?", "글쎄요? 아줌마한테는 주고 싶지 않아요!",
        "아… 맞다. 이 캣잎 가까이서 냄새 맡아볼래? 이거 되게 비싼건데 특별히 맡게 해줄게.", "음 좋아요! (킁킁) 근데 갑자기 왜 이렇게 세상이 빙글빙글 돌아요?",
        "(입가에 미소를 띄우며) 기분 좋지? 이제 이 구슬은 내가 가져갈게.", "아 안돼요! (얼른 도망가야 해! 고양이들을 피해 다른 곳으로 가자!)"
        });

        // 에너지 구슬 합체
        talkData.Add(500, new string[] { "엇 이거 아까 술 취한 아저씨한테 받은 거랑 비슷하게 생긴 것 같은데?",
        "한번 합쳐볼까?"
        });

        // 스테이지 4
        talkData.Add(600, new string[] { "여긴 어디지? 우주인가?", "저건…운석?! 운석이 날라온다. 피해야 돼!"
        });

        // 결말
        talkData.Add(700, new string[] { "여긴… 뭐지?", "엄마…? 아빠?",
        "네로…? 네로니?!", "엄마! 아빠! 너무 너무 보고 싶었어요. (훌쩍거리며)",
        "정말 네로구나!", "보고 싶었다 네로야! 무사해서 다행이야." });

        // Talker Data
        talkerData[0] = "네로";

        // 스테이지1
        // 1번맵
        talkerData[110] = "말 많은 부하 고양이";
        talkerData[111] = "애교 많은 부하 고양이";
        talkerData[112] = "대장 고양이";
        talkerData[113] = "할아버지 고양이";

        // 스테이지2
        // 1번맵
        talkerData[200] = "술 취한 아저씨";

        // 2번맵
        talkerData[210] = "여자 아이";

        // 3번맵
        talkerData[220] = "캣잎에 취한 고양이1";
        talkerData[221] = "캣잎에 취한 고양이2";
        talkerData[222] = "캣잎에 취한 고양이3";
        talkerData[223] = "캣잎에 취한 고양이4";
        talkerData[224] = "캣잎에 취한 고양이5";
        talkerData[225] = "캣잎에 취한 고양이6";
        talkerData[226] = "캣잎 상점 아줌마";

        talkerData[300] = "네로의 엄마 & 아빠";
        talkerData[301] = "네로 엄마";
        talkerData[302] = "네로 아빠";
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public string GetTalker(int id)
    {
        return talkerData[id];
    }
}
