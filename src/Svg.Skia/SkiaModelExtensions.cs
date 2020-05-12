﻿using System.Collections.Generic;
using SkiaSharp;
using Svg.Model;

namespace Svg.Skia
{
    public static class SkiaModelExtensions
    {
        public static SKPoint ToSKPoint(this Point point)
        {
            return new SKPoint(point.X, point.Y);
        }

        public static SKPoint[] ToSKPoints(this IList<Point> points)
        {
            var skPoints = new SKPoint[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                skPoints[i] = points[i].ToSKPoint();
            }

            return skPoints;
        }

        public static SKPointI ToSKPointI(this PointI pointI)
        {
            return new SKPointI(pointI.X, pointI.Y);
        }

        public static SKRect ToSKRect(this Rect rect)
        {
            return new SKRect(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        public static SKMatrix ToSKMatrix(this Matrix matrix)
        {
            return new SKMatrix(
                matrix.ScaleX,
                matrix.SkewX,
                matrix.TransX,
                matrix.SkewY,
                matrix.ScaleY,
                matrix.TransY,
                matrix.Persp0,
                matrix.Persp1,
                matrix.Persp2);
        }

        public static SKPaintStyle ToSKPaintStyle(this PaintStyle paintStyle)
        {
            switch (paintStyle)
            {
                default:
                case PaintStyle.Fill:
                    return SKPaintStyle.Fill;
                case PaintStyle.Stroke:
                    return SKPaintStyle.Stroke;
                case PaintStyle.StrokeAndFill:
                    return SKPaintStyle.StrokeAndFill;
            }
        }

        public static SKStrokeCap ToSKStrokeCap(this StrokeCap strokeCap)
        {
            switch (strokeCap)
            {
                default:
                case StrokeCap.Butt:
                    return SKStrokeCap.Butt;
                case StrokeCap.Round:
                    return SKStrokeCap.Round;
                case StrokeCap.Square:
                    return SKStrokeCap.Square;
            }
        }

        public static SKStrokeJoin ToSKStrokeJoin(this StrokeJoin strokeJoin)
        {
            switch (strokeJoin)
            {
                default:
                case StrokeJoin.Miter:
                    return SKStrokeJoin.Miter;
                case StrokeJoin.Round:
                    return SKStrokeJoin.Round;
                case StrokeJoin.Bevel:
                    return SKStrokeJoin.Bevel;
            }
        }

        public static SKTextAlign ToSKTextAlign(this TextAlign textAlign)
        {
            switch (textAlign)
            {
                default:
                case TextAlign.Left:
                    return SKTextAlign.Left;
                case TextAlign.Center:
                    return SKTextAlign.Center;
                case TextAlign.Right:
                    return SKTextAlign.Right;
            }
        }

        public static SKFontStyleWeight ToSKFontStyleWeight(this FontStyleWeight fontStyleWeight)
        {
            switch (fontStyleWeight)
            {
                default:
                case FontStyleWeight.Invisible:
                    return SKFontStyleWeight.Invisible;
                case FontStyleWeight.Thin:
                    return SKFontStyleWeight.Thin;
                case FontStyleWeight.ExtraLight:
                    return SKFontStyleWeight.ExtraLight;
                case FontStyleWeight.Light:
                    return SKFontStyleWeight.Light;
                case FontStyleWeight.Normal:
                    return SKFontStyleWeight.Normal;
                case FontStyleWeight.Medium:
                    return SKFontStyleWeight.Medium;
                case FontStyleWeight.SemiBold:
                    return SKFontStyleWeight.SemiBold;
                case FontStyleWeight.Bold:
                    return SKFontStyleWeight.Bold;
                case FontStyleWeight.ExtraBold:
                    return SKFontStyleWeight.ExtraBold;
                case FontStyleWeight.Black:
                    return SKFontStyleWeight.Black;
                case FontStyleWeight.ExtraBlack:
                    return SKFontStyleWeight.ExtraBlack;
            }
        }

        public static SKFontStyleWidth ToSKFontStyleWidth(this FontStyleWidth fontStyleWidth)
        {
            switch (fontStyleWidth)
            {
                default:
                case FontStyleWidth.UltraCondensed:
                    return SKFontStyleWidth.UltraCondensed;
                case FontStyleWidth.ExtraCondensed:
                    return SKFontStyleWidth.ExtraCondensed;
                case FontStyleWidth.Condensed:
                    return SKFontStyleWidth.Condensed;
                case FontStyleWidth.SemiCondensed:
                    return SKFontStyleWidth.SemiCondensed;
                case FontStyleWidth.Normal:
                    return SKFontStyleWidth.Normal;
                case FontStyleWidth.SemiExpanded:
                    return SKFontStyleWidth.SemiExpanded;
                case FontStyleWidth.Expanded:
                    return SKFontStyleWidth.Expanded;
                case FontStyleWidth.ExtraExpanded:
                    return SKFontStyleWidth.ExtraExpanded;
                case FontStyleWidth.UltraExpanded:
                    return SKFontStyleWidth.UltraExpanded;
            }
        }

        public static SKFontStyleSlant ToSKFontStyleSlant(this FontStyleSlant fontStyleSlant)
        {
            switch (fontStyleSlant)
            {
                default:
                case FontStyleSlant.Upright:
                    return SKFontStyleSlant.Upright;
                case FontStyleSlant.Italic:
                    return SKFontStyleSlant.Italic;
                case FontStyleSlant.Oblique:
                    return SKFontStyleSlant.Oblique;
            }
        }

        public static SKTypeface? ToSKTypeface(this Typeface? typeface)
        {
            if (typeface == null || typeface.FamilyName == null)
            {
                return null;
            }
            return SKTypeface.FromFamilyName(
                    typeface.FamilyName,
                    typeface.Weight.ToSKFontStyleWeight(),
                    typeface.Width.ToSKFontStyleWidth(),
                    typeface.Style.ToSKFontStyleSlant());
        }

        public static SKColor ToSKColor(this Color color)
        {
            return new SKColor(color.Red, color.Green, color.Blue, color.Alpha);
        }

        public static SKColor[] ToSKColors(this Color[] colors)
        {
            var skColors = new SKColor[colors.Length];

            for (int i = 0; i < colors.Length; i++)
            {
                skColors[i] = colors[i].ToSKColor();
            }

            return skColors;
        }

        public static SKShaderTileMode ToSKShaderTileMode(this ShaderTileMode shaderTileMode)
        {
            switch (shaderTileMode)
            {
                default:
                case ShaderTileMode.Clamp:
                    return SKShaderTileMode.Clamp;
                case ShaderTileMode.Repeat:
                    return SKShaderTileMode.Repeat;
                case ShaderTileMode.Mirror:
                    return SKShaderTileMode.Mirror;
            }
        }

        public static SKShader? ToSKShader(this Shader? shader)
        {
            switch (shader)
            {
                case ColorShader colorShader:
                    {
                        return SKShader.CreateColor(colorShader.Color.ToSKColor());
                    }
                case LinearGradientShader linearGradientShader:
                    {
                        if (linearGradientShader.Colors == null || linearGradientShader.ColorPos == null)
                        {
                            return null;
                        }

                        if (linearGradientShader.LocalMatrix != null)
                        {
                            return SKShader.CreateLinearGradient(
                                linearGradientShader.Start.ToSKPoint(),
                                linearGradientShader.End.ToSKPoint(),
                                linearGradientShader.Colors.ToSKColors(),
                                linearGradientShader.ColorPos,
                                linearGradientShader.Mode.ToSKShaderTileMode(),
                                linearGradientShader.LocalMatrix.Value.ToSKMatrix());
                        }
                        else
                        {
                            return SKShader.CreateLinearGradient(
                                linearGradientShader.Start.ToSKPoint(),
                                linearGradientShader.End.ToSKPoint(),
                                linearGradientShader.Colors.ToSKColors(),
                                linearGradientShader.ColorPos,
                                linearGradientShader.Mode.ToSKShaderTileMode());
                        }
                    }
                case TwoPointConicalGradientShader twoPointConicalGradientShader:
                    {
                        if (twoPointConicalGradientShader.Colors == null || twoPointConicalGradientShader.ColorPos == null)
                        {
                            return null;
                        }

                        if (twoPointConicalGradientShader.LocalMatrix != null)
                        {
                            return SKShader.CreateTwoPointConicalGradient(
                                twoPointConicalGradientShader.Start.ToSKPoint(),
                                twoPointConicalGradientShader.StartRadius,
                                twoPointConicalGradientShader.End.ToSKPoint(),
                                twoPointConicalGradientShader.EndRadius,
                                twoPointConicalGradientShader.Colors.ToSKColors(),
                                twoPointConicalGradientShader.ColorPos,
                                twoPointConicalGradientShader.Mode.ToSKShaderTileMode(),
                                twoPointConicalGradientShader.LocalMatrix.Value.ToSKMatrix());
                        }
                        else
                        {
                            return SKShader.CreateTwoPointConicalGradient(
                                twoPointConicalGradientShader.Start.ToSKPoint(),
                                twoPointConicalGradientShader.StartRadius,
                                twoPointConicalGradientShader.End.ToSKPoint(),
                                twoPointConicalGradientShader.EndRadius,
                                twoPointConicalGradientShader.Colors.ToSKColors(),
                                twoPointConicalGradientShader.ColorPos,
                                twoPointConicalGradientShader.Mode.ToSKShaderTileMode());
                        }
                    }
                case PictureShader pictureShader:
                    {
                        if (pictureShader.Src == null)
                        {
                            return null;
                        }

                        return SKShader.CreatePicture(
                            pictureShader.Src.ToSKPicture(),
                            SKShaderTileMode.Repeat,
                            SKShaderTileMode.Repeat,
                            pictureShader.LocalMatrix.ToSKMatrix(),
                            pictureShader.Tile.ToSKRect());
                    }
                case PerlinNoiseFractalNoiseShader perlinNoiseFractalNoiseShader:
                    {
                        return SKShader.CreatePerlinNoiseFractalNoise(
                            perlinNoiseFractalNoiseShader.BaseFrequencyX,
                            perlinNoiseFractalNoiseShader.BaseFrequencyY,
                            perlinNoiseFractalNoiseShader.NumOctaves,
                            perlinNoiseFractalNoiseShader.Seed,
                            perlinNoiseFractalNoiseShader.TileSize.ToSKPointI());
                    }
                case PerlinNoiseTurbulenceShader perlinNoiseTurbulenceShader:
                    {
                        return SKShader.CreatePerlinNoiseTurbulence(
                            perlinNoiseTurbulenceShader.BaseFrequencyX,
                            perlinNoiseTurbulenceShader.BaseFrequencyY,
                            perlinNoiseTurbulenceShader.NumOctaves,
                            perlinNoiseTurbulenceShader.Seed,
                            perlinNoiseTurbulenceShader.TileSize.ToSKPointI());
                    }
                default:
                    return null;
            }
        }

        public static SKColorFilter? ToSKColorFilter(this ColorFilter? colorFilter)
        {
            switch (colorFilter)
            {
                case BlendModeColorFilter blendModeColorFilter:
                    {
                        return SKColorFilter.CreateBlendMode(
                            blendModeColorFilter.Color.ToSKColor(),
                            blendModeColorFilter.Mode.ToSKBlendMode());  
                    }
                case ColorMatrixColorFilter colorMatrixColorFilter:
                    {
                        if (colorMatrixColorFilter.Matrix == null)
                        {
                            return null;
                        }
                        return SKColorFilter.CreateColorMatrix(colorMatrixColorFilter.Matrix);
                    }
                case LumaColorColorFilter _:
                    {
                        return SKColorFilter.CreateLumaColor();
                    }
                // TODO:
                default:
                    return null;
            }
        }

        public static SKImageFilter.CropRect ToCropRect(this CropRect cropRect)
        {
            return new SKImageFilter.CropRect(cropRect.Rect.ToSKRect());
        }

        public static SKImageFilter? ToSKImageFilter(this ImageFilter? imageFilter)
        {
            switch (imageFilter)
            {
                case PaintImageFilter paintImageFilter:
                    {
                        return SKImageFilter.CreatePaint(
                            paintImageFilter.Paint.ToSKPaint(),
                            paintImageFilter.CropRect.ToCropRect());
                    }
                // TODO:
                default:
                    return null;
            }
        }

        public static SKPathEffect? ToSKPathEffect(this PathEffect? pathEffect)
        {
            switch (pathEffect)
            {
                case DashPathEffect dashPathEffect:
                    {
                        return SKPathEffect.CreateDash(
                            dashPathEffect.Intervals,
                            dashPathEffect.Phase);
                    }
                // TODO:
                default:
                    return null;
            }
        }

        public static SKBlendMode ToSKBlendMode(this BlendMode blendMode)
        {
            switch (blendMode)
            {
                default:
                case BlendMode.Clear:
                    return SKBlendMode.Clear;
                case BlendMode.Src:
                    return SKBlendMode.Src;
                case BlendMode.Dst:
                    return SKBlendMode.Dst;
                case BlendMode.SrcOver:
                    return SKBlendMode.SrcOver;
                case BlendMode.DstOver:
                    return SKBlendMode.DstOver;
                case BlendMode.SrcIn:
                    return SKBlendMode.SrcIn;
                case BlendMode.DstIn:
                    return SKBlendMode.DstIn;
                case BlendMode.SrcOut:
                    return SKBlendMode.SrcOut;
                case BlendMode.DstOut:
                    return SKBlendMode.DstOut;
                case BlendMode.SrcATop:
                    return SKBlendMode.SrcATop;
                case BlendMode.DstATop:
                    return SKBlendMode.DstATop;
                case BlendMode.Xor:
                    return SKBlendMode.Xor;
                case BlendMode.Plus:
                    return SKBlendMode.Plus;
                case BlendMode.Modulate:
                    return SKBlendMode.Modulate;
                case BlendMode.Screen:
                    return SKBlendMode.Screen;
                case BlendMode.Overlay:
                    return SKBlendMode.Overlay;
                case BlendMode.Darken:
                    return SKBlendMode.Darken;
                case BlendMode.Lighten:
                    return SKBlendMode.Lighten;
                case BlendMode.ColorDodge:
                    return SKBlendMode.ColorDodge;
                case BlendMode.ColorBurn:
                    return SKBlendMode.ColorBurn;
                case BlendMode.HardLight:
                    return SKBlendMode.HardLight;
                case BlendMode.SoftLight:
                    return SKBlendMode.SoftLight;
                case BlendMode.Difference:
                    return SKBlendMode.Difference;
                case BlendMode.Exclusion:
                    return SKBlendMode.Exclusion;
                case BlendMode.Multiply:
                    return SKBlendMode.Multiply;
                case BlendMode.Hue:
                    return SKBlendMode.Hue;
                case BlendMode.Saturation:
                    return SKBlendMode.Saturation;
                case BlendMode.Color:
                    return SKBlendMode.Color;
                case BlendMode.Luminosity:
                    return SKBlendMode.Luminosity;
            }
        }

        public static SKFilterQuality ToSKFilterQuality(this FilterQuality filterQuality)
        {
            switch (filterQuality)
            {
                default:
                case FilterQuality.None:
                    return SKFilterQuality.None;
                case FilterQuality.Low:
                    return SKFilterQuality.Low;
                case FilterQuality.Medium:
                    return SKFilterQuality.Medium;
                case FilterQuality.High:
                    return SKFilterQuality.High;
            }
        }

        public static SKPaint ToSKPaint(this Paint paint)
        {
            return new SKPaint()
            {
                Style = paint.Style.ToSKPaintStyle(),
                IsAntialias = paint.IsAntialias,
                StrokeWidth = paint.StrokeWidth,
                StrokeCap = paint.StrokeCap.ToSKStrokeCap(),
                StrokeJoin = paint.StrokeJoin.ToSKStrokeJoin(),
                StrokeMiter = paint.StrokeMiter,
                TextSize = paint.TextSize,
                TextAlign = paint.TextAlign.ToSKTextAlign(),
                Typeface = paint.Typeface?.ToSKTypeface(),
                Color = paint.Color == null ? SKColor.Empty : ToSKColor(paint.Color.Value),
                Shader = paint.Shader?.ToSKShader(),
                ColorFilter = paint.ColorFilter?.ToSKColorFilter(),
                ImageFilter = paint.ImageFilter?.ToSKImageFilter(),
                PathEffect = paint.PathEffect?.ToSKPathEffect(),
                BlendMode = paint.BlendMode.ToSKBlendMode(),
                FilterQuality = paint.FilterQuality.ToSKFilterQuality()
            };
        }

        public static SKClipOperation ToSKClipOperation(this ClipOperation clipOperation)
        {
            switch (clipOperation)
            {
                default:
                case ClipOperation.Difference:
                    return SKClipOperation.Difference;
                case ClipOperation.Intersect:
                    return SKClipOperation.Intersect;
            }
        }

        public static SKPathFillType ToSKPathFillType(this PathFillType pathFillType)
        {
            switch (pathFillType)
            {
                default:
                case PathFillType.Winding:
                    return SKPathFillType.Winding;
                case PathFillType.EvenOdd:
                    return SKPathFillType.EvenOdd;
            }
        }

        public static SKPathArcSize ToSKPathArcSize(this PathArcSize pathArcSize)
        {
            switch (pathArcSize)
            {
                default:
                case PathArcSize.Small:
                    return SKPathArcSize.Small;
                case PathArcSize.Large:
                    return SKPathArcSize.Large;
            }
        }

        public static SKPathDirection ToSKPathDirection(this PathDirection pathDirection)
        {
            switch (pathDirection)
            {
                default:
                case PathDirection.Clockwise:
                    return SKPathDirection.Clockwise;
                case PathDirection.CounterClockwise:
                    return SKPathDirection.CounterClockwise;
            }
        }

        public static SKPath ToSKPath(this Path path)
        {
            var skPath = new SKPath()
            {
                FillType = path.FillType.ToSKPathFillType()
            };

            if (path.Commands != null)
            {
                foreach (var pathCommand in path.Commands)
                {
                    switch (pathCommand)
                    {
                        case MoveToPathCommand moveToPathCommand:
                            {
                                skPath.MoveTo(moveToPathCommand.X, moveToPathCommand.Y);
                            }
                            break;
                        case LineToPathCommand lineToPathCommand:
                            {
                                skPath.LineTo(lineToPathCommand.X, lineToPathCommand.Y);
                            }
                            break;
                        case ArcToPathCommand arcToPathCommand:
                            {
                                skPath.ArcTo(
                                    arcToPathCommand.RX,
                                    arcToPathCommand.RY,
                                    arcToPathCommand.XAxisRotate,
                                    arcToPathCommand.LargeArc.ToSKPathArcSize(),
                                    arcToPathCommand.Sweep.ToSKPathDirection(),
                                    arcToPathCommand.X,
                                    arcToPathCommand.Y);
                            }
                            break;
                        case QuadToPathCommand quadToPathCommand:
                            {
                                skPath.QuadTo(
                                    quadToPathCommand.X0, quadToPathCommand.Y0,
                                    quadToPathCommand.X1, quadToPathCommand.Y1);
                            }
                            break;
                        case CubicToPathCommand cubicToPathCommand:
                            {
                                skPath.CubicTo(
                                    cubicToPathCommand.X0, cubicToPathCommand.Y0,
                                    cubicToPathCommand.X1, cubicToPathCommand.Y1,
                                    cubicToPathCommand.X2, cubicToPathCommand.Y2);
                            }
                            break;
                        case ClosePathCommand _:
                            {
                                skPath.Close();
                            }
                            break;
                        case AddRectPathCommand addRectPathCommand:
                            {
                                skPath.AddRect(addRectPathCommand.Rect.ToSKRect());
                            }
                            break;
                        case AddRoundRectPathCommand addRoundRectPathCommand:
                            {
                                skPath.AddRoundRect(
                                    addRoundRectPathCommand.Rect.ToSKRect(),
                                    addRoundRectPathCommand.RX,
                                    addRoundRectPathCommand.RY);
                            }
                            break;
                        case AddOvalPathCommand addOvalPathCommand:
                            {
                                skPath.AddOval(addOvalPathCommand.Rect.ToSKRect());
                            }
                            break;
                        case AddCirclePathCommand addCirclePathCommand:
                            {
                                skPath.AddCircle(
                                    addCirclePathCommand.X,
                                    addCirclePathCommand.Y,
                                    addCirclePathCommand.Radius);
                            }
                            break;
                        case AddPolyPathCommand addPolyPathCommand:
                            {
                                skPath.AddPoly(
                                    addPolyPathCommand.Points.ToSKPoints(),
                                    addPolyPathCommand.Close);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return skPath;
        }

        public static SKPicture? ToSKPicture(this Picture? picture)
        {
            if (picture == null)
            {
                return null;
            }

            var skRect = picture.CullRect.ToSKRect();
            using var skPictureRecorder = new SKPictureRecorder();
            using var skCanvas = skPictureRecorder.BeginRecording(skRect);

            if (picture.Commands != null)
            {
                foreach (var pictureCommand in picture.Commands)
                {
                    switch (pictureCommand)
                    {
                        case ClipPathPictureCommand clipPathPictureCommand:
                            {
                                skCanvas.ClipPath(
                                    clipPathPictureCommand.Path.ToSKPath(),
                                    clipPathPictureCommand.Operation.ToSKClipOperation(),
                                    clipPathPictureCommand.Antialias);
                            }
                            break;
                        case ClipRectPictureCommand clipRectPictureCommand:
                            {
                                skCanvas.ClipRect(
                                    clipRectPictureCommand.Rect.ToSKRect(),
                                    clipRectPictureCommand.Operation.ToSKClipOperation(),
                                    clipRectPictureCommand.Antialias);
                            }
                            break;
                        case SavePictureCommand savePictureCommand:
                            {
                                skCanvas.Save();
                            }
                            break;
                        case RestorePictureCommand restorePictureCommand:
                            {
                                skCanvas.Restore();
                            }
                            break;
                        case SetMatrixPictureCommand setMatrixPictureCommand:
                            {
                                skCanvas.SetMatrix(setMatrixPictureCommand.Matrix.ToSKMatrix());
                            }
                            break;
                        case SaveLayerPictureCommand saveLayerPictureCommand:
                            {
                                if (saveLayerPictureCommand.Paint != null)
                                {
                                    skCanvas.SaveLayer(saveLayerPictureCommand.Paint.ToSKPaint());
                                }
                                else
                                {
                                    skCanvas.SaveLayer();
                                }
                            }
                            break;
                        case DrawPathPictureCommand drawPathPictureCommand:
                            {
                                skCanvas.DrawPath(
                                    drawPathPictureCommand.Path.ToSKPath(),
                                    drawPathPictureCommand.Paint.ToSKPaint());
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return skPictureRecorder.EndRecording();
        }
    }
}
