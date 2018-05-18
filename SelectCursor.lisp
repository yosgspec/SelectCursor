;カーソル選択モジュール
(defun SelectCursor(items)
(let ((cursor 0))
(flet (
	;カーソルの移動
	(move(x max)
		(incf cursor x)
		(when(< cursor 0) (setf cursor 0))
		(when(< (1- max) cursor) (setf cursor (1- max)))
	)

	;カーソルの表示
	(view()
		(let (
			(select (loop for i from 0 below (length items) collect nil))
			(s "")
		)
			(setf (elt select cursor) t)
			(loop for i from 0 below (length items) do
				(setf s (format nil (if(elt select i) "~A[~A]" "~A~A") s (elt items i)))
			)
			(format t "~A~c" s #\return)
		)
	)
)
	(view)
	(loop (let ((ch (#__getch)))
		(when(= ch #x0d)
			(format t "~%")
			(return cursor)
		)
		(when(= ch #xe0)
			(setf ch (#__getch))
			(when(= ch #x4b) (move -1 (length items)))	;左
			(when(= ch #x4d) (move 1 (length items)))	;右
		)
		(view)
	))
)))

(let ((items '("壱" "弍" "参" "四" "五" "六" "七" "八" "九" "拾")))
	(loop
		(format t "SelectedItem: ~A~%" (elt items (SelectCursor items)))
	)
)
(quit)