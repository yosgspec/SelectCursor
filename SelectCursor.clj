;カーソル選択モジュール
(defn SelectCursor[items]
(let [cursor(atom 0)]
(let [
	;カーソルの移動
	move(fn[x max]
		(reset! cursor (+ @cursor x))
		(when(< @cursor 0) (reset! cursor 0))
		(when(< (dec max) @cursor) (reset! cursor (dec max)))
	)

	;カーソルの表示
	view(fn[]
		(let [
			select (map atom (repeat(count items) false))
			s (atom "")
		]
			(reset! (nth select @cursor) true)
			(loop[i 0](when(< i (count items))
				(reset! s (format (if @(nth select i) "%s[%s]" "%s%s") @s (nth items i)))
			(recur(inc i))))
			(printf "%s\r" @s)
		)
	)
]

	(view)
	(loop[] (let [ch (System.Console/ReadKey true)]
		(if(= (.Key ch) ConsoleKey/Enter)
			(println)
		(do
			(when(= (.Key ch) ConsoleKey/LeftArrow) (move -1 (count items)))	;左
			(when(= (.Key ch) ConsoleKey/RightArrow) (move 1 (count items)))	;右
			(view)
			(recur)
		))
	))
	@cursor
)))

(let [items ["壱" "弍" "参" "四" "五" "六" "七" "八" "九" "拾"]]
	(loop[]
		(printf "SelectedItem: %s\n" (nth items (SelectCursor items)))
	(recur)))
)
