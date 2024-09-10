import React from "react";

const mathMLTutorial = () => {
    return (
        <>
            <h3>MathML Tutorial</h3>
            <div>
                Detta är ett bråk:
                <math>
                    <mfrac>
                        <mn>1</mn>
                        <mn>4</mn>
                    </mfrac>
                </math>
                <br />
                <br />
                <math>
                    <mfrac>
                        <mn>1</mn>
                        <mn>2</mn>
                    </mfrac>
                    <mo>+</mo>
                    <mfrac>
                        <mn>2</mn>
                        <mn>3</mn>
                    </mfrac>
                    <mo>=</mo>
                    <mfrac>
                        <mn>(3 + 4)</mn>
                        <mn>6</mn>
                    </mfrac>
                    <mo>=</mo>
                    <mfrac>
                        <mn>7</mn>
                        <mn>6</mn>
                    </mfrac>
                    <mo>=</mo>
                    <mo>1</mo>
                    <mfrac>
                        <mn>1</mn>
                        <mn>6</mn>
                    </mfrac>
                </math>
            </div>
            <div>
                <math display="block">
                    <mrow>
                        <mo>(</mo>
                        <mtable>
                            <mtr>
                                <mtd>
                                    <mi>a</mi>
                                </mtd>
                                <mtd>
                                    <mi>c</mi>
                                </mtd>
                                <mtd>
                                    <mn>0</mn>
                                </mtd>
                                <mtd>
                                    <msub>
                                        <mi>t</mi>
                                        <mi>x</mi>
                                    </msub>
                                </mtd>
                            </mtr>
                            <mtr>
                                <mtd>
                                    <mi>b</mi>
                                </mtd>
                                <mtd>
                                    <mi>d</mi>
                                </mtd>
                                <mtd>
                                    <mn>0</mn>
                                </mtd>
                                <mtd>
                                    <msub>
                                        <mi>t</mi>
                                        <mi>y</mi>
                                    </msub>
                                </mtd>
                            </mtr>
                            <mtr>
                                <mtd>
                                    <mn>0</mn>
                                </mtd>
                                <mtd>
                                    <mn>0</mn>
                                </mtd>
                                <mtd>
                                    <mn>1</mn>
                                </mtd>
                                <mtd>
                                    <mn>0</mn>
                                </mtd>
                            </mtr>
                            <mtr>
                                <mtd>
                                    <mn>0</mn>
                                </mtd>
                                <mtd>
                                    <mn>0</mn>
                                </mtd>
                                <mtd>
                                    <mn>0</mn>
                                </mtd>
                                <mtd>
                                    <mn>1</mn>
                                </mtd>
                            </mtr>
                        </mtable>
                        <mo>)</mo>
                    </mrow>
                </math>
            </div>
        </>
    );
}

export default mathMLTutorial;